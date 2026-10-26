using System.ComponentModel.DataAnnotations;

namespace UmbrellaCorpHRSystem.Models.Dto.Office
{
    public class ElevateAccessDto
    {
        [Required(ErrorMessage = "PASSWORD REQUIRED")]
        public string Password { get; set; } = string.Empty;
    }
}
