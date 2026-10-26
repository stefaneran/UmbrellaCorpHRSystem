using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using UmbrellaCorpHRSystem.Data;
using UmbrellaCorpHRSystem.Models.Dto.Employee;
using UmbrellaCorpHRSystem.Models.Entities.Employees;
using UmbrellaCorpHRSystem.Models.Enums;
using UmbrellaCorpHRSystem.Models.ViewModels.Employees;

namespace UmbrellaCorpHRSystem.Services.Employees
{
    public class EmployeesService : IEmployeesService
    {
        private readonly UmbrellaHRSystemDbContext _dbContext = null!;

        public EmployeesService(UmbrellaHRSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EmployeeTableViewModel> GetEmployeesAsync(int page)
        {
            int pageSize = 10;
            int totalEmployeeCount = _dbContext.Employees.Count();
             
            ICollection<EmployeeTableRowViewModel> employees = await _dbContext.Employees
                .OrderBy(g => g.FirstName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(g => new EmployeeTableRowViewModel()
                {
                    Id = g.Id,
                    Name = $"{g.FirstName} {g.LastName}",
                    Department = g.Department,
                    AnnualLeaveLeft = g.TotalAnnualLeave - g.UsedAnnualLeave,
                    EmploymentType = g.EmploymentType,
                    EmploymentStatus = g.EmploymentStatus,
                    CurrentLocation = g.CurrentLocation,
                    HeartRate = g.HeartRate,
                    InfectionStatus = g.InfectionStatus,
                    LifeStatus = g.LifeStatus,
                })
                .ToListAsync();

            return new EmployeeTableViewModel()
            {
                TotalEmployeeCount = totalEmployeeCount,
                Employees = employees
            };
        }

        public async Task<EmployeeDetailsInfoViewModel?> GetEmployeeDetailsAsync(int id)
        {
            EmployeeDetailsInfoViewModel? employee = await _dbContext.Employees
                .Where(g => g.Id == id)
                .Select(g => new EmployeeDetailsInfoViewModel()
                {
                    Name = $"{g.FirstName} {g.LastName}",
                    Email = g.Email,
                    Salary = g.Salary,
                    Department = g.Department,
                    EmploymentType = g.EmploymentType,
                    EmploymentStatus = g.EmploymentStatus,
                    TotalAnnualLeave = g.TotalAnnualLeave,
                    UsedAnnualLeave = g.UsedAnnualLeave,
                    HeartRate = g.HeartRate,
                    CurrentLocation = g.CurrentLocation,
                    InfectionStatus = g.InfectionStatus,
                    LifeStatus = g.LifeStatus,
                })
                .FirstOrDefaultAsync();

            return employee;
        }

        public async Task<CreateEditEmployeeDto?> GetEmployeeForEditAsync(int id)
        {
            CreateEditEmployeeDto? employeeDto = await _dbContext.Employees
                .Where(g => g.Id == id)
                .Select(g => new CreateEditEmployeeDto()
                {
                    Id = id,
                    FirstName = g.FirstName,
                    LastName = g.LastName,
                    Department = g.Department,
                    EmploymentType = g.EmploymentType,
                    EmploymentStatus = g.EmploymentStatus,
                    Salary = g.Salary,
                    TotalAnnualLeave = g.TotalAnnualLeave
                })
                .FirstOrDefaultAsync();
            return employeeDto;
        }

        public async Task<int> CreateEmployeeAsync(CreateEditEmployeeDto createEmployeeDto)
        {
            Random rand = new Random();
            Employee newEmployee = new Employee()
            {
                FirstName = createEmployeeDto.FirstName,
                LastName = createEmployeeDto.LastName,
                Email = $"{createEmployeeDto.FirstName}{createEmployeeDto.LastName}@umbrellacorp.com".ToLowerInvariant(),
                Salary = createEmployeeDto.Salary,
                Department = createEmployeeDto.Department,
                EmploymentType = createEmployeeDto.EmploymentType,
                EmploymentStatus = createEmployeeDto.EmploymentStatus,
                TotalAnnualLeave = createEmployeeDto.TotalAnnualLeave,
                UsedAnnualLeave = 0,
                HeartRate = rand.Next(60, 80),
                CurrentLocation = DepartmentExtension.GetDefaultLocation(createEmployeeDto.Department),
                InfectionStatus = InfectionStatus.Uninfected,
                LifeStatus = LifeStatus.Alive
            };
            _dbContext.Employees.Add(newEmployee);
            await _dbContext.SaveChangesAsync();
            return newEmployee.Id;
        }

        public async Task<bool> EditEmployeeAsync(CreateEditEmployeeDto editEmployeeDto)
        {
            if (editEmployeeDto.Id == 0)
            {
                return false;
            }
            var employee = await _dbContext.FindAsync<Employee>(editEmployeeDto.Id);
            if (employee == null)
            {
                return false;
            }
            employee.FirstName = editEmployeeDto.FirstName;
            employee.LastName = editEmployeeDto.LastName;
            employee.Salary = editEmployeeDto.Salary;
            employee.TotalAnnualLeave = editEmployeeDto.TotalAnnualLeave;
            employee.Department = editEmployeeDto.Department;
            employee.EmploymentStatus = editEmployeeDto.EmploymentStatus;
            employee.EmploymentType = editEmployeeDto.EmploymentType;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            int deletedRowsNum = await _dbContext.Employees
                .Where(g => g.Id == id)
                .ExecuteDeleteAsync();
            return deletedRowsNum > 0;
        }
    }
}
