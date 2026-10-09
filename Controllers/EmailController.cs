using Microsoft.AspNetCore.Mvc;
using UmbrellaCorpHRSystem.Data;
using UmbrellaCorpHRSystem.Models.ViewModels.Email;

namespace UmbrellaCorpHRSystem.Controllers
{
    public class EmailController : Controller
    {
        protected readonly ApplicationDbContext _dbContext;

        public EmailController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int? Id)
        {
            ICollection<EmailThreadMessageViewModel> EmailThreadMessages = new List<EmailThreadMessageViewModel>();
            ICollection <EmailThreadListItemViewModel> EmailThreadList = _dbContext.EmailThreads
                    .Where(g => g.RecipientEmail == "claireredfield@umbrellacorp.com")
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
                    .ToList();

            if (Id != null)
            {
                EmailThreadMessages = _dbContext.EmailMessages
                .Where(g => g.EmailThreadId == Id)
                .Select(g => new EmailThreadMessageViewModel
                {
                    SenderEmail = g.SenderEmail,
                    RecipientEmail = g.RecipientEmail,
                    Subject = g.Subject,
                    Body = g.Body,
                    SentDate = g.SentDate
                })
                .OrderBy(g => g.SentDate)
                .ToList();
            }

            EmailIndexViewModel EmailIndexModel = new EmailIndexViewModel
            {
                SelectedThreadId = Id ?? 0,
                EmailThreadsList = EmailThreadList,
                EmailThreadMessages = EmailThreadMessages,
            };

            return View(EmailIndexModel);
        }

        [HttpGet]
        public IActionResult OpenThread(int Id)
        {
            ICollection<EmailThreadMessageViewModel> EmailThreadMessages = _dbContext.EmailMessages
                .Where(g => g.EmailThreadId == Id)
                .Select(g => new EmailThreadMessageViewModel
                {
                    SenderEmail = g.SenderEmail,
                    RecipientEmail = g.RecipientEmail,
                    Subject = g.Subject,
                    Body = g.Body,
                    SentDate = g.SentDate
                })
                .OrderBy(g => g.SentDate)
                .ToList();

            return PartialView("_EmailThread", EmailThreadMessages);
        }
    }
}
