using System.ComponentModel.DataAnnotations;

namespace UmbrellaCorpHRSystem.Models.Dto.Email
{
    public class SendEmailDto
    {

        [Required]
        [EmailAddress]
        public string RecipientEmail {  get; set; } = string.Empty;

        [Required]
        [MaxLength(128)]
        public string? Subject { get; set; } = string.Empty;

        [Required]
        [MaxLength(2048)]
        public string? Body { get; set; } = string.Empty;
         
    }
}
