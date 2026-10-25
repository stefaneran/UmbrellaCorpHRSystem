using System.ComponentModel.DataAnnotations;
using UmbrellaCorpHRSystem.Models.Enums;

namespace UmbrellaCorpHRSystem.Models.Entities.Employees
{
    public class Employee
    {
        public int Id { get; set; }

        [MaxLength(32)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(32)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(128)]
        public string Email { get; set;  } = string.Empty;

        public int Salary { get; set; }

        public int TotalAnnualLeave { get; set; }

        public int UsedAnnualLeave { get; set; }

        public Department Department { get; set; }

        public EmploymentType EmploymentType { get; set; }

        public EmploymentStatus EmploymentStatus { get; set; }

        public int HeartRate { get; set; }

        [MaxLength(64)]
        public string CurrentLocation { get; set; } = string.Empty;

        public InfectionStatus InfectionStatus { get; set; }

        public LifeStatus LifeStatus { get; set; }
    }
}
