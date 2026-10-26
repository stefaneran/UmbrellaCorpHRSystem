using System.ComponentModel.DataAnnotations;

namespace UmbrellaCorpHRSystem.Models.Entities.Email
{
    public class EmailMessage
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmailThreadId { get; set; }

        [Required]
        public EmailThread EmailThread { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string SenderEmail { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string RecipientEmail { get; set; } = string.Empty;

        [Required]
        [MaxLength(128)]
        public string Subject { get; set; } = string.Empty;

        [Required]
        [MaxLength(2048)]
        public string Body { get; set; } = string.Empty;

        [Required]
        public DateTime SentDate { get; set; } = DateTime.UtcNow;


    }
}
