using UmbrellaCorpHRSystem.Models.Dto.Employee;
using UmbrellaCorpHRSystem.Models.ViewModels.Employees;

namespace UmbrellaCorpHRSystem.Services.Employees
{
    public interface IEmployeesService
    {
        /// <summary>
        /// Get list of employees based on current pagination page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<EmployeeTableViewModel> GetEmployeesAsync(int page);

        /// <summary>
        /// Get details of single employee by ID for viewing purposes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EmployeeDetailsInfoViewModel?> GetEmployeeDetailsAsync(int id);

        /// <summary>
        /// Get details of single employee by ID for editing purposes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CreateEditEmployeeDto?> GetEmployeeForEditAsync(int id);

        /// <summary>
        /// Create a new employee
        /// </summary>
        /// <param name="createEmployeeDto"></param>
        /// <returns></returns>
        Task<int> CreateEmployeeAsync(CreateEditEmployeeDto createEmployeeDto);

        /// <summary>
        /// Edit an existing employee
        /// </summary>
        /// <param name="editEmployeeDto"></param>
        /// <returns></returns>
        Task<bool> EditEmployeeAsync(CreateEditEmployeeDto editEmployeeDto);

        /// <summary>
        /// Delete an existing employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
