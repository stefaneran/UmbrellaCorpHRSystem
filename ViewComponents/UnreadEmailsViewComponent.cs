using Microsoft.AspNetCore.Mvc;
using UmbrellaCorpHRSystem.Services.Email;

namespace UmbrellaCorpHRSystem.ViewComponents
{
    public class UnreadEmailsViewComponent : ViewComponent
    {
        private readonly IEmailService _emailService;

        public UnreadEmailsViewComponent(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int numOfUnreadEmails = await _emailService.GetNumOfUnreadEmailsAsync(UserClaimsPrincipal);
            return View(numOfUnreadEmails);
        }
    }
}