namespace UmbrellaCorpHRSystem.Models.ViewModels.Email
{
    public class EmailThreadMessageViewModel
    {
        public string SenderEmail { get; set; } = string.Empty;
        public string RecipientEmail { get; set; } = string.Empty;
        public DateTime SentDate { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
