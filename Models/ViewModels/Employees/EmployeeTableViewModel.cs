namespace UmbrellaCorpHRSystem.Models.ViewModels.Employees
{
    public class EmployeeTableViewModel
    {
        public int TotalEmployeeCount { get; set; }
        public ICollection<EmployeeTableRowViewModel> Employees { get; set; } = new List<EmployeeTableRowViewModel>();
    }
}
