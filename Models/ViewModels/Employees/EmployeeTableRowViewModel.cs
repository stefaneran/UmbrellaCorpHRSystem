using UmbrellaCorpHRSystem.Models.Enums;

namespace UmbrellaCorpHRSystem.Models.ViewModels.Employees
{
    public class EmployeeTableRowViewModel
    {
        public string Name { get; set; } = string.Empty;
        public Department Department { get; set; }
        public int AnnualLeaveLeft { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
        public int HeartRate { get; set; }
        public string CurrentLocation { get; set; } = string.Empty;
        public InfectionStatus InfectionStatus { get; set; }
        public LifeStatus LifeStatus { get; set; }
    }
}
