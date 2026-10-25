namespace UmbrellaCorpHRSystem.Models.ViewModels.Employees
{
    public class EmployeesIndexViewModel
    {
        public int CurrentPage { get; set; }
        public EmployeeTableViewModel EmployeeTable { get; set; } = new EmployeeTableViewModel();
        public bool CreateMode { get; set; }
    }
}
