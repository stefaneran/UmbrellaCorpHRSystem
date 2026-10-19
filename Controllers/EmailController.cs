using Microsoft.AspNetCore.Mvc;
using UmbrellaCorpHRSystem.Models.Dto.Email;
using UmbrellaCorpHRSystem.Models.ViewModels.Email;
using UmbrellaCorpHRSystem.Services.Email;

namespace UmbrellaCorpHRSystem.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<IActionResult> Index(
            int? ThreadId, 
            string? RecipientEmail,
            bool IsWriting = false, 
            string Show = "incoming"
        )
        {
            ICollection<EmailThreadListItemViewModel> emailThreadList = await _emailService.GetEmailThreadListAsync(Show);
            EmailThreadViewModel? emailThread = await _emailService.GetEmailThreadAsync(ThreadId);

            EmailIndexViewModel emailIndexModel = new EmailIndexViewModel
            {
                Show = Show,
                IsWriting = IsWriting,
                RecipientEmail = RecipientEmail,
                EmailThreadsList = emailThreadList,
                EmailThread = emailThread
            };

            return View(emailIndexModel);
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(SendEmailDto sendEmailDto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            var newEmailThreadId = await _emailService.SendEmailAsync(sendEmailDto);
            return RedirectToAction(nameof(Index), new { ThreadId = newEmailThreadId });
        }

        [HttpPost]
        public async Task<IActionResult> ReplyEmail(ReplyEmailDto replyEmailDto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            bool success = await _emailService.ReplyEmailAsync(replyEmailDto);
            if (!success)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index), new { replyEmailDto.ThreadId });
        }


    }
}
