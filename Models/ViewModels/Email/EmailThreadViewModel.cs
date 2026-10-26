using UmbrellaCorpHRSystem.Models.Dto.Email;

namespace UmbrellaCorpHRSystem.Models.ViewModels.Email
{
    public class EmailThreadViewModel
    {
        public int Id { get; set; }
        public ReplyEmailDto ReplyEmailDto { get; set; } = new ReplyEmailDto();
        public ICollection<EmailMessageViewModel> Messages { get; set; } = new List<EmailMessageViewModel>();
    }
}
