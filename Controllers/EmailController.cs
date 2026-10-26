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

        private async Task<EmailIndexViewModel> GetIndexViewModel(
            bool isWriting, 
            int? threadId, 
            string? recipientEmail,
            SendEmailDto? sendEmailDto,
            ReplyEmailDto? replyEmailDto)
        {
            ICollection<EmailThreadListItemViewModel> emailThreadList = await _emailService.GetEmailThreadListAsync(User);

            EmailThreadViewModel? emailThread = await _emailService.GetEmailThreadAsync(threadId);
            if (emailThread != null && replyEmailDto != null)
            {
                emailThread.ReplyEmailDto = replyEmailDto;
            }

            EmailIndexViewModel emailIndexModel = new EmailIndexViewModel
            {
                IsWriting = isWriting,
                RecipientEmail = recipientEmail,
                EmailThreadsList = emailThreadList,
                EmailThread = emailThread,
                SendEmailDto = sendEmailDto
            };

            return emailIndexModel;
        }

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(
            int? threadId, 
            string? recipientEmail,
            bool isWriting = false)
        {
            EmailIndexViewModel emailIndexModel = await GetIndexViewModel(isWriting, threadId, recipientEmail, null, null);
            return View(emailIndexModel);
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(SendEmailDto sendEmailDto)
        {
            if (!ModelState.IsValid)
            {
                EmailIndexViewModel emailIndexModel = await GetIndexViewModel(true, null, sendEmailDto.RecipientEmail, sendEmailDto, null);
                return View(nameof(Index), emailIndexModel);
            }
            var newEmailThreadId = await _emailService.SendEmailAsync(User, sendEmailDto);
            return RedirectToAction(nameof(Index), new { ThreadId = newEmailThreadId });
        }

        [HttpPost]
        public async Task<IActionResult> ReplyEmail(ReplyEmailDto replyEmailDto)
        {
            if (!ModelState.IsValid)
            {
                EmailIndexViewModel emailIndexModel = await GetIndexViewModel(false, replyEmailDto.Id, null, null, replyEmailDto);
                return View(nameof(Index), emailIndexModel);
            }
            bool success = await _emailService.ReplyEmailAsync(User, replyEmailDto);
            if (!success)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index), new { threadId = replyEmailDto.Id });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteThread(int id)
        {
            await _emailService.DeleteEmailThreadAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
