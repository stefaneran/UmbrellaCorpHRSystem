using System.ComponentModel.DataAnnotations;
using UmbrellaCorpHRSystem.Models.Enums;

namespace UmbrellaCorpHRSystem.Models.Dto.Employee
{
    public class CreateEditEmployeeDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public int Salary { get; set; }

        [Required]
        public int TotalAnnualLeave { get; set; }

        [Required]
        public Department Department { get; set; }

        [Required]
        public EmploymentType EmploymentType { get; set; }

        [Required]
        public EmploymentStatus EmploymentStatus { get; set; }
    }
}
