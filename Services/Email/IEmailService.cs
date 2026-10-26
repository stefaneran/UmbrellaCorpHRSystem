using System.Security.Claims;
using UmbrellaCorpHRSystem.Models.Dto.Email;
using UmbrellaCorpHRSystem.Models.ViewModels.Email;

namespace UmbrellaCorpHRSystem.Services.Email
{
    public interface IEmailService
    {
        /// <summary>
        /// Get list of email threads as options showing the initial sender, subject line and time sent.
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        Task<ICollection<EmailThreadListItemViewModel>> GetEmailThreadListAsync(ClaimsPrincipal principal);

        /// <summary>
        /// Get the full email thread including all messages within it
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<EmailThreadViewModel?> GetEmailThreadAsync(ClaimsPrincipal principal, int? Id);

        /// <summary>
        /// Send an email starting a new thread
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="sendEmailDto"></param>
        /// <returns></returns>
        Task<int> SendEmailAsync(ClaimsPrincipal principal, SendEmailDto sendEmailDto);

        /// <summary>
        /// Reply to an existing email thread
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="replyEmailDto"></param>
        /// <returns></returns>
        Task<bool> ReplyEmailAsync(ClaimsPrincipal principal, ReplyEmailDto replyEmailDto);

        /// <summary>
        /// Delete an existing email thread with all its messages
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteEmailThreadAsync(ClaimsPrincipal principal, int id);
    }
}
