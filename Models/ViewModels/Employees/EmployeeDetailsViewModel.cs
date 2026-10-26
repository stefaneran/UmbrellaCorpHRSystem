using UmbrellaCorpHRSystem.Models.Dto.Employee;

namespace UmbrellaCorpHRSystem.Models.ViewModels.Employees
{
    public class EmployeeDetailsViewModel
    {
        public int Id { get; set; }
        public EmployeeDetailsInfoViewModel EmployeeInfo { get; set; } = new EmployeeDetailsInfoViewModel();
        public bool EditMode { get; set; }
        public CreateEditEmployeeDto EditEmployeeDto { get; set; } = new CreateEditEmployeeDto();
    }
}
