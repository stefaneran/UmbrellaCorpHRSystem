using Microsoft.EntityFrameworkCore;
using UmbrellaCorpHRSystem.Data;
using UmbrellaCorpHRSystem.Models.Dto.Email;
using UmbrellaCorpHRSystem.Models.Email;
using UmbrellaCorpHRSystem.Models.ViewModels.Email;

namespace UmbrellaCorpHRSystem.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly ApplicationDbContext _dbContext = null!;

        public EmailService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<EmailThreadListItemViewModel>> GetEmailThreadListAsync(string Show)
        {
            ICollection<EmailThreadListItemViewModel> emailThreadList = await _dbContext.EmailThreads
                    .Where(g =>
                        Show == "incoming" ?
                            g.RecipientEmail == "claireredfield@umbrellacorp.com" :
                            g.SenderEmail == "claireredfield@umbrellacorp.com"
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

        public async Task<int> SendEmailAsync(SendEmailDto sendEmailDto)
        {
            EmailThread newEmailThread = new EmailThread()
            {
                SenderEmail = sendEmailDto.SenderEmail,
                RecipientEmail = sendEmailDto.RecipientEmail,
                EmailMessages =
                {
                    new EmailMessage()
                    {
                        SenderEmail = sendEmailDto.SenderEmail,
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

        public async Task<bool> ReplyEmailAsync(ReplyEmailDto replyEmailDto)
        {
            var lastMessage = await _dbContext.EmailMessages
                .Where(g => g.EmailThreadId == replyEmailDto.ThreadId)
                .OrderByDescending(g => g.SentDate)
                .Select(g => new { g.SenderEmail, g.RecipientEmail })
                .FirstOrDefaultAsync();

            if (lastMessage == null) 
            {
                return false;
            }

            EmailMessage newEmailMessage = new EmailMessage()
            {
                EmailThreadId = replyEmailDto.ThreadId,
                SenderEmail = lastMessage.RecipientEmail,
                RecipientEmail = lastMessage.SenderEmail,
                Subject = replyEmailDto.Subject ?? "No Subject",
                Body = replyEmailDto.Body ?? string.Empty,
                SentDate = DateTime.UtcNow
            };

            _dbContext.EmailMessages.Add(newEmailMessage);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
