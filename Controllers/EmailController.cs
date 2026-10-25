using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmbrellaCorpHRSystem.Models.Dto.Email;
using UmbrellaCorpHRSystem.Models.ViewModels.Email;
using UmbrellaCorpHRSystem.Services.Email;

namespace UmbrellaCorpHRSystem.Controllers
{
    [Authorize]
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<IActionResult> Index(
            int? threadId, 
            string? recipientEmail,
            bool isWriting = false
        )
        {
            ICollection<EmailThreadListItemViewModel> emailThreadList = await _emailService.GetEmailThreadListAsync(User);
            EmailThreadViewModel? emailThread = await _emailService.GetEmailThreadAsync(threadId);

            EmailIndexViewModel emailIndexModel = new EmailIndexViewModel
            {
                IsWriting = isWriting,
                RecipientEmail = recipientEmail,
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
            var newEmailThreadId = await _emailService.SendEmailAsync(User, sendEmailDto);
            return RedirectToAction(nameof(Index), new { ThreadId = newEmailThreadId });
        }

        [HttpPost]
        public async Task<IActionResult> ReplyEmail(ReplyEmailDto replyEmailDto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            bool success = await _emailService.ReplyEmailAsync(User, replyEmailDto);
            if (!success)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index), new { replyEmailDto.ThreadId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteThread(int id)
        {
            await _emailService.DeleteEmailThreadAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
