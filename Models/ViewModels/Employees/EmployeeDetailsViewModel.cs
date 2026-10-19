using UmbrellaCorpHRSystem.Models.Dto.Employee;

namespace UmbrellaCorpHRSystem.Models.ViewModels.Employees
{
    public class EmployeeDetailsViewModel
    {
        public EmployeeDetailsInfoViewModel EmployeeInfo { get; set; } = new EmployeeDetailsInfoViewModel();
        public CreateEditEmployeeDto EmployeeDto { get; set; } = new CreateEditEmployeeDto();
        public bool EditMode { get; set; }
    }
}
