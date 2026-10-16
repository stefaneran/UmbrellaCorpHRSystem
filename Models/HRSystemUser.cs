using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using UmbrellaCorpHRSystem.Models.Enums;

namespace UmbrellaCorpHRSystem.Models
{
    public class HRSystemUser : IdentityUser
    {
        [MaxLength(32)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(32)]
        public string LastName { get; set; } = string.Empty;

    }
}
