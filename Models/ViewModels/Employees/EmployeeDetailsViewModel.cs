using System.ComponentModel.DataAnnotations;
using UmbrellaCorpHRSystem.Models.Enums;

namespace UmbrellaCorpHRSystem.Models.ViewModels.Employees
{
    public class EmployeeDetailsViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Salary { get; set; }
        public int TotalAnnualLeave { get; set; }
        public int UsedAnnualLeave { get; set; }
        public Department Department { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
        public int HeartRate { get; set; }
        public string CurrentLocation { get; set; } = string.Empty;
        public InfectionStatus InfectionStatus { get; set; }
        public LifeStatus LifeStatus { get; set; }
    }
}
