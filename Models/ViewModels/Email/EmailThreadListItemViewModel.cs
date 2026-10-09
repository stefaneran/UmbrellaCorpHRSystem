namespace UmbrellaCorpHRSystem.Models.ViewModels.Email
{
    public class EmailThreadListItemViewModel
    {
        public int Id { get; set; }
        public string SenderEmail { get; set; } = string.Empty;
        public string Subject {  get; set; } = string.Empty;
        public DateTime SentDate {  get; set; }

    }
}
