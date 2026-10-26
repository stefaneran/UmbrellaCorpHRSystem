using System.Security.Claims;
using UmbrellaCorpHRSystem.Models.Dto.Email;
using UmbrellaCorpHRSystem.Models.ViewModels.Email;

namespace UmbrellaCorpHRSystem.Services.Email
{
    public interface IEmailService
    {
        Task<ICollection<EmailThreadListItemViewModel>> GetEmailThreadListAsync(ClaimsPrincipal principal);
        Task<EmailThreadViewModel?> GetEmailThreadAsync(ClaimsPrincipal principal, int? Id);
        Task<int> SendEmailAsync(ClaimsPrincipal principal, SendEmailDto sendEmailDto);
        Task<bool> ReplyEmailAsync(ClaimsPrincipal principal, ReplyEmailDto replyEmailDto);
        Task<bool> DeleteEmailThreadAsync(ClaimsPrincipal principal, int id);
    }
}
