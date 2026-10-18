using UmbrellaCorpHRSystem.Models.ViewModels.Employees;

namespace UmbrellaCorpHRSystem.Services.Employees
{
    public interface IEmployeesService
    {
        Task<ICollection<EmployeeTableRowViewModel>> GetEmployeesAsync();
        Task<EmployeeDetailsViewModel> GetEmployeeDetailsAsync(int Id);
    }
}
