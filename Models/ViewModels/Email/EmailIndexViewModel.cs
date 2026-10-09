namespace UmbrellaCorpHRSystem.Models.ViewModels.Email
{
    public class EmailIndexViewModel
    {
        public int SelectedThreadId { get; set; }
        public ICollection<EmailThreadListItemViewModel> EmailThreadsList { get; set; } = new HashSet<EmailThreadListItemViewModel>();
        public ICollection<EmailThreadMessageViewModel> EmailThreadMessages { get; set; } = new HashSet<EmailThreadMessageViewModel>();
    }
}
