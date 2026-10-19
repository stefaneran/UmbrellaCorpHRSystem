using UmbrellaCorpHRSystem.Models.Dto.Employee;
using UmbrellaCorpHRSystem.Models.ViewModels.Employees;

namespace UmbrellaCorpHRSystem.Services.Employees
{
    public interface IEmployeesService
    {
        Task<ICollection<EmployeeTableRowViewModel>> GetEmployeesAsync();
        Task<EmployeeDetailsInfoViewModel?> GetEmployeeDetailsAsync(int id);
        Task<CreateEditEmployeeDto?> GetEmployeeForEditAsync(int id);
        Task<int> CreateEmployeeAsync(CreateEditEmployeeDto createEmployeeDto);
        Task<bool> EditEmployeeAsync(CreateEditEmployeeDto editEmployeeDto);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
