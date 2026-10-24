namespace UmbrellaCorpHRSystem.Models.ViewModels.Employees
{
    public class EmployeesIndexViewModel
    {
        public EmployeeTableViewModel EmployeeTable { get; set; } = new EmployeeTableViewModel();
        public bool CreateMode { get; set; }
    }
}
