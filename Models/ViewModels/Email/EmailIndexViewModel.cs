namespace UmbrellaCorpHRSystem.Models.ViewModels.Email
{
    public class EmailIndexViewModel
    {
        public string? Show { get; set; } = "incoming";
        public bool IsWriting { get; set; }
        public string? RecipientEmail { get; set; }
        public ICollection<EmailThreadListItemViewModel> EmailThreadsList { get; set; } = new HashSet<EmailThreadListItemViewModel>();
        public EmailThreadViewModel? EmailThread { get; set; }
    }
}
