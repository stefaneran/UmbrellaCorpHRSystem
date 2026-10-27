using System.Security.Claims;
using UmbrellaCorpHRSystem.Models.Dto.Email;
using UmbrellaCorpHRSystem.Models.ViewModels.Email;

namespace UmbrellaCorpHRSystem.Services.Email
{
    public interface IEmailService
    {
        /// <summary>
        /// Get number of unread email threads for the provided user
        /// </summary>
        Task<int> GetNumOfUnreadEmailsAsync(ClaimsPrincipal principal);

        /// <summary>
        /// Get list of email threads as options showing the initial sender, subject line and time sent.
        /// </summary>
        Task<ICollection<EmailThreadListItemViewModel>> GetEmailThreadListAsync(ClaimsPrincipal principal);

        /// <summary>
        /// Get the full email thread including all messages within it
        /// </summary>
        Task<EmailThreadViewModel?> GetEmailThreadAsync(ClaimsPrincipal principal, int? Id);

        /// <summary>
        /// Send an email starting a new thread
        /// </summary>
        Task<int> SendEmailAsync(ClaimsPrincipal principal, SendEmailDto sendEmailDto);

        /// <summary>
        /// Reply to an existing email thread
        /// </summary>
        Task<bool> ReplyEmailAsync(ClaimsPrincipal principal, ReplyEmailDto replyEmailDto);

        /// <summary>
        /// Delete an existing email thread with all its messages
        /// </summary>
        Task<bool> DeleteEmailThreadAsync(ClaimsPrincipal principal, int id);
    }
}
