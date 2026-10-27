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

            EmailThreadViewModel? emailThread = await _emailService.GetEmailThreadAsync(User, threadId);
            // If an Email thread is loaded and we have an existing ReplyEmailDto, assign the prefilled DTO
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

            // If we are requesting an email thread that doesn't exist, return NotFound
            if (threadId != null && emailIndexModel.EmailThread == null)
            {
                return NotFound();
            }

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

            int newEmailThreadId = await _emailService.SendEmailAsync(User, sendEmailDto);

            // If ID is returned as -1 that means the recipient does not exist in the system
            if (newEmailThreadId == -1)
            {
                ModelState.AddModelError(nameof(SendEmailDto.RecipientEmail), "Error: User with this Email does not exist.");
                EmailIndexViewModel emailIndexModel = await GetIndexViewModel(true, null, sendEmailDto.RecipientEmail, sendEmailDto, null);
                return View(nameof(Index), emailIndexModel);
            }

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
            bool success = await _emailService.DeleteEmailThreadAsync(User, id);

            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
