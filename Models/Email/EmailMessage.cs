using System.ComponentModel.DataAnnotations;

namespace UmbrellaCorpHRSystem.Models.Email
{
    public class EmailMessage
    {
        [Key]
        public int Id { get; set; }

        public int EmailThreadId { get; set; }

        public EmailThread EmailThread { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string SenderEmail { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string RecipientEmail { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Subject { get; set; } = string.Empty;

        [Required]
        [MaxLength(2056)]
        public string Body { get; set; } = string.Empty;

        public DateTime SentDate { get; set; } = DateTime.UtcNow;


    }
}
