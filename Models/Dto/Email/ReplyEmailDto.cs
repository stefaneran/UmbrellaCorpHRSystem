using System.ComponentModel.DataAnnotations;

namespace UmbrellaCorpHRSystem.Models.Dto.Email
{
    public class ReplyEmailDto
    {
        [Required]
        public int ThreadId { get; set; }

        [MaxLength(128)]
        public string? Subject { get; set; } = string.Empty;

        [MaxLength(2048)]
        public string? Body { get; set; } = string.Empty;
    }
}
