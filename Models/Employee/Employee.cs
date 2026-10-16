using UmbrellaCorpHRSystem.Models.Enums;

namespace UmbrellaCorpHRSystem.Models.Employee
{
    public class Employee
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set;  } = string.Empty;
        public string CurrentLocation { get; set; } = string.Empty;
        public int Salary { get; set; }
        public int TotalAnnualLeave { get; set; }
        public int UsedAnnualLeave { get; set; }
        public Department Department { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
    }
}
