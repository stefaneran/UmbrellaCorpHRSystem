namespace UmbrellaCorpHRSystem.Models.ViewModels.Employees
{
    public class EmployeesIndexViewModel
    {
        public ICollection<EmployeeTableRowViewModel> Employees { get; set; } = new List<EmployeeTableRowViewModel>();
        public bool CreateMode { get; set; }
    }
}
