using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Principal;
using UmbrellaCorpHRSystem.Data;
using UmbrellaCorpHRSystem.Models;
using UmbrellaCorpHRSystem.Models.Dto.Email;
using UmbrellaCorpHRSystem.Models.Entities.Email;
using UmbrellaCorpHRSystem.Models.ViewModels.Email;

namespace UmbrellaCorpHRSystem.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly ApplicationDbContext _dbContext = null!;
        private readonly UserManager<HRSystemUser> _userManager;

        public EmailService(
            ApplicationDbContext dbContext,
            UserManager<HRSystemUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<ICollection<EmailThreadListItemViewModel>> GetEmailThreadListAsync(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            ICollection<EmailThreadListItemViewModel> emailThreadList = await _dbContext.EmailThreads
                    .Where(g =>
                            g.RecipientEmail == user.Email ||
                            g.SenderEmail == user.Email
                    )
                    .Select(g => new EmailThreadListItemViewModel
                    {
                        Id = g.Id,
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

        public async Task<EmailThreadViewModel?> GetEmailThreadAsync(int? Id)
        {
            if (Id == null)
            {
                return null;
            }
            EmailThreadViewModel? emailThread = await _dbContext.EmailThreads
                .Where(g => g.Id == Id)
                .Select(g => new EmailThreadViewModel()
                {
                    Id = g.Id,
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

            return emailThread;
        }

        public async Task<int> SendEmailAsync(ClaimsPrincipal principal, SendEmailDto sendEmailDto)
        {
            var user = await _userManager.GetUserAsync(principal);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
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
                throw new ArgumentNullException(nameof(user));
            }
            var emailThread = await _dbContext.EmailThreads
                .Where(g => g.Id == replyEmailDto.Id)
                .Select(g => new { 
                    g.SenderEmail, 
                    g.RecipientEmail 
                })
                .FirstOrDefaultAsync();

            if (emailThread == null)
            {
                return false;
            }
            string senderEmail = user.Email ?? throw new InvalidOperationException();
            if ((senderEmail != emailThread.SenderEmail) && (senderEmail != emailThread.RecipientEmail))
            {
                return false;
            }
            string recipientEmail = senderEmail == emailThread.SenderEmail ? emailThread.RecipientEmail : emailThread.SenderEmail;

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

        public async Task<bool> DeleteEmailThreadAsync(int id)
        {
            int deletedRowsNum = await _dbContext.EmailThreads
                .Where(g => g.Id == id)
                .ExecuteDeleteAsync();
            return deletedRowsNum > 0;
        }
    }
}
