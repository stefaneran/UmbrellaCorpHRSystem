using System.ComponentModel.DataAnnotations;
using UmbrellaCorpHRSystem.Models.Enums;

namespace UmbrellaCorpHRSystem.Models.Entities.Employees
{
    public class Employee
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(32)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(128)]
        public string Email { get; set;  } = string.Empty;

        [Required]
        public int Salary { get; set; }

        [Required]
        public int TotalAnnualLeave { get; set; }

        [Required]
        public int UsedAnnualLeave { get; set; }

        [Required]
        public Department Department { get; set; }

        [Required]
        public EmploymentType EmploymentType { get; set; }

        [Required]
        public EmploymentStatus EmploymentStatus { get; set; }

        [Required]
        public int HeartRate { get; set; }

        [Required]
        [MaxLength(64)]
        public string CurrentLocation { get; set; } = string.Empty;

        [Required]
        public InfectionStatus InfectionStatus { get; set; }

        [Required]
        public LifeStatus LifeStatus { get; set; }
    }
}
