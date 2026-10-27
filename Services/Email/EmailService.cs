using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Security.Claims;
using UmbrellaCorpHRSystem.Data;
using UmbrellaCorpHRSystem.Models;
using UmbrellaCorpHRSystem.Models.Dto.Email;
using UmbrellaCorpHRSystem.Models.Entities.Email;
using UmbrellaCorpHRSystem.Models.ViewModels.Email;

namespace UmbrellaCorpHRSystem.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly UmbrellaHRSystemDbContext _dbContext = null!;
        private readonly UserManager<HRSystemUser> _userManager;

        public EmailService(
            UmbrellaHRSystemDbContext dbContext,
            UserManager<HRSystemUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        private record EmailParticipants(string Sender, string Recipient);

        /// <summary>
        /// Check if logged-in user is either a sender or a recipient of the email thread
        /// </summary>
        private async Task<bool> CheckIfUserEligibleForOperation(string? userEmail, int? threadId)
        {
            EmailParticipants? emailParticipants = await _dbContext.EmailThreads
                .Where(g => g.Id == threadId)
                .Select(g => new EmailParticipants(g.SenderEmail, g.RecipientEmail))
                .FirstOrDefaultAsync();

            return emailParticipants?.Sender == userEmail || emailParticipants?.Recipient == userEmail;
        }

        public async Task<int> GetNumOfUnreadEmailsAsync(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            if (user == null)
            {
                return 0;
            }

            int numOfUnreadEmailThreads = await _dbContext.EmailThreads
                .Where(g =>
                    g.RecipientEmail == user.Email && !g.IsRead
                )
                .CountAsync();

            return numOfUnreadEmailThreads;
        }

        public async Task<ICollection<EmailThreadListItemViewModel>> GetEmailThreadListAsync(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            if (user == null)
            {
                return null;
            }

            ICollection<EmailThreadListItemViewModel> emailThreadList = await _dbContext.EmailThreads
                    .Where(g =>
                            g.RecipientEmail == user.Email ||
                            g.SenderEmail == user.Email
                    )
                    .Select(g => new EmailThreadListItemViewModel
                    {
                        Id = g.Id,
                        IsRead = g.IsRead,
                        SenderEmail = g.SenderEmail,
                        Subject = g.EmailMessages
                            .OrderByDescending(m => m.SentDate)
                            .Select(m => m.Subject)
                            .FirstOrDefault() ?? string.Empty,
                        SentDate = g.EmailMessages.Max(m => m.SentDate)
                    })
                    .OrderByDescending(g => g.SentDate)
                    .ToListAsync();

            return emailThreadList;
        }

        public async Task<EmailThreadViewModel?> GetEmailThreadAsync(ClaimsPrincipal principal, int? id)
        {
            if (id == null)
            {
                return null;
            }

            var user = await _userManager.GetUserAsync(principal);
            if (user == null)
            {
                return null;
            }

            if (!await CheckIfUserEligibleForOperation(user.Email, id))
            {
                return null;
            }

            EmailThreadViewModel? emailThread = await _dbContext.EmailThreads
                .Where(g => g.Id == id)
                .Select(g => new EmailThreadViewModel()
                {
                    Id = g.Id,
                    IsRead = g.IsRead,
                    ReplyEmailDto = new ReplyEmailDto()
                    {
                        Id = g.Id,
                        Subject = "",
                        Body = ""
                    },
                    Messages = g.EmailMessages
                        .OrderBy(m => m.SentDate)
                        .Select(m => new EmailMessageViewModel()
                        {
                            SenderEmail = m.SenderEmail,
                            RecipientEmail = m.RecipientEmail,
                            SentDate = m.SentDate,
                            Subject = m.Subject,
                            Body = m.Body
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            if (emailThread != null && emailThread.IsRead == false)
            {
                await _dbContext.EmailThreads
                    .Where(g => g.Id == emailThread.Id)
                    .ExecuteUpdateAsync(g =>
                        g.SetProperty(p => p.IsRead, true));
            }

            return emailThread;
        }

        public async Task<int> SendEmailAsync(ClaimsPrincipal principal, SendEmailDto sendEmailDto)
        {
            var user = await _userManager.GetUserAsync(principal);
            if (user == null)
            {
                return -1;
            }

            var recipient = await _dbContext.Employees
                .Where(g => g.Email == sendEmailDto.RecipientEmail.ToLowerInvariant())
                .FirstOrDefaultAsync();
            if (recipient == null)
            {
                return -1;
            }

            EmailThread newEmailThread = new EmailThread()
            {
                SenderEmail = user.Email ?? "",
                RecipientEmail = sendEmailDto.RecipientEmail,
                EmailMessages =
                {
                    new EmailMessage()
                    {
                        SenderEmail = user.Email ?? "",
                        RecipientEmail = sendEmailDto.RecipientEmail,
                        Subject = sendEmailDto.Subject ?? "No Subject",
                        Body = sendEmailDto.Body ?? string.Empty,
                        SentDate = DateTime.UtcNow
                    }
                }
            };
            _dbContext.EmailThreads.Add(newEmailThread);
            await _dbContext.SaveChangesAsync();
            return newEmailThread.Id;
        }

        public async Task<bool> ReplyEmailAsync(ClaimsPrincipal principal, ReplyEmailDto replyEmailDto)
        {
            var user = await _userManager.GetUserAsync(principal);
            if (user == null)
            {
                return false;
            }

            EmailParticipants? emailParticipants = await _dbContext.EmailThreads
                .Where(g => g.Id == replyEmailDto.Id)
                .Select(g => new EmailParticipants(g.SenderEmail, g.RecipientEmail))
                .FirstOrDefaultAsync();

            if (emailParticipants == null)
            {
                return false;
            }

            string senderEmail = user.Email ?? throw new InvalidOperationException();
            if ((senderEmail != emailParticipants?.Sender) && (senderEmail != emailParticipants?.Recipient))
            {
                return false;
            }

            string recipientEmail = senderEmail == emailParticipants.Sender ? emailParticipants.Recipient : emailParticipants.Sender;

            EmailMessage newEmailMessage = new EmailMessage()
            {
                EmailThreadId = replyEmailDto.Id,
                SenderEmail = senderEmail,
                RecipientEmail = recipientEmail,
                Subject = replyEmailDto.Subject ?? "No Subject",
                Body = replyEmailDto.Body ?? string.Empty,
                SentDate = DateTime.UtcNow
            };

            _dbContext.EmailMessages.Add(newEmailMessage);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEmailThreadAsync(ClaimsPrincipal principal, int id)
        {
            var user = await _userManager.GetUserAsync(principal);
            if (user == null)
            {
                return false;
            }

            if (!await CheckIfUserEligibleForOperation(user.Email, id))
            {
                return false;
            }

            int deletedRowsNum = await _dbContext.EmailThreads
                .Where(g => g.Id == id)
                .ExecuteDeleteAsync();

            return deletedRowsNum > 0;
        }
    }
}
