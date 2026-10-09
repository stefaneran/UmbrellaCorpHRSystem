using System.ComponentModel.DataAnnotations;

namespace UmbrellaCorpHRSystem.Models.Email
{
    public class EmailThread
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string SenderEmail { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string RecipientEmail { get; set; } = string.Empty;

        public ICollection<EmailMessage> EmailMessages { get; set; } = new HashSet<EmailMessage>();
    }
}
