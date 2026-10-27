using UmbrellaCorpHRSystem.Models.Dto.Employee;
using UmbrellaCorpHRSystem.Models.ViewModels.Employees;

namespace UmbrellaCorpHRSystem.Services.Employees
{
    public interface IEmployeesService
    {
        /// <summary>
        /// Get list of employees based on current pagination page
        /// </summary>
        Task<EmployeeTableViewModel> GetEmployeesAsync(int page);

        /// <summary>
        /// Get details of single employee by ID for viewing purposes
        /// </summary>
        Task<EmployeeDetailsInfoViewModel?> GetEmployeeDetailsAsync(int id);

        /// <summary>
        /// Get details of single employee by ID for editing purposes
        /// </summary>
        Task<CreateEditEmployeeDto?> GetEmployeeForEditAsync(int id);

        /// <summary>
        /// Create a new employee
        /// </summary>
        Task<int> CreateEmployeeAsync(CreateEditEmployeeDto createEmployeeDto);

        /// <summary>
        /// Edit an existing employee
        /// </summary>
        Task<bool> EditEmployeeAsync(CreateEditEmployeeDto editEmployeeDto);

        /// <summary>
        /// Delete an existing employee
        /// </summary>
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
