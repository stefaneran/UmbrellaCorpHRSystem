namespace UmbrellaCorpHRSystem.Models.ViewModels.Email
{
    public class EmailThreadViewModel
    {
        public int Id { get; set; }

        public ICollection<EmailMessageViewModel> Messages { get; set; } = new List<EmailMessageViewModel>();
    }
}
