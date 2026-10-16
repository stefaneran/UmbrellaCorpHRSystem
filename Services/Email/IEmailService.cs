using UmbrellaCorpHRSystem.Models.Dto.Email;
using UmbrellaCorpHRSystem.Models.ViewModels.Email;

namespace UmbrellaCorpHRSystem.Services.Email
{
    public interface IEmailService
    {
        Task<ICollection<EmailThreadListItemViewModel>> GetEmailThreadListAsync(string Show);
        Task<EmailThreadViewModel?> GetEmailThreadAsync(int? Id);
        Task<int> SendEmailAsync(SendEmailDto sendEmailDto);
        Task<bool> ReplyEmailAsync(ReplyEmailDto replyEmailDto);
    }
}
