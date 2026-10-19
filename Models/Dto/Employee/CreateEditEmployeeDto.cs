using System.ComponentModel.DataAnnotations;
using UmbrellaCorpHRSystem.Models.Enums;

namespace UmbrellaCorpHRSystem.Models.Dto.Employee
{
    public class CreateEditEmployeeDto
    {
        public int? Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public int Salary { get; set; }

        public int TotalAnnualLeave { get; set; } = 25;

        [Required]
        public Department Department { get; set; }

        [Required]
        public EmploymentType EmploymentType { get; set; }

        [Required]
        public EmploymentStatus EmploymentStatus { get; set; }
    }
}
