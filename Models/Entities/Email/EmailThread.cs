using System.ComponentModel.DataAnnotations;

namespace UmbrellaCorpHRSystem.Models.Entities.Email
{
    public class EmailThread
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public bool IsRead { get; set; } = false;

        [Required]
        [EmailAddress]
        public string SenderEmail { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string RecipientEmail { get; set; } = string.Empty;

        [Required]
        public ICollection<EmailMessage> EmailMessages { get; set; } = new HashSet<EmailMessage>();
    }
}
