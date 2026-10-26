using System.ComponentModel.DataAnnotations;
using UmbrellaCorpHRSystem.Models.Enums;

namespace UmbrellaCorpHRSystem.Models.Dto.Employee
{
    public class CreateEditEmployeeDto
    {
        private const int MinSalary = 15000;
        private const int MaxSalary = 999999999;
        private const int MinimumLeave = 13;
        private const int MaxLeave = 60;

        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(32)]
        public string LastName { get; set; } = string.Empty;

        [Range(MinSalary, MaxSalary)]
        public int Salary { get; set; }

        [Range(MinimumLeave, MaxLeave)]
        public int TotalAnnualLeave { get; set; } = 25;

        [Required]
        public Department Department { get; set; }

        [Required]
        public EmploymentType EmploymentType { get; set; }

        [Required]
        public EmploymentStatus EmploymentStatus { get; set; }
    }
}
