using Microsoft.EntityFrameworkCore;
using UmbrellaCorpHRSystem.Data;
using UmbrellaCorpHRSystem.Models.ViewModels.Employees;

namespace UmbrellaCorpHRSystem.Services.Employees
{
    public class EmployeesService : IEmployeesService
    {
        private readonly ApplicationDbContext _dbContext = null!;

        public EmployeesService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<EmployeeTableRowViewModel>> GetEmployeesAsync()
        {
            ICollection<EmployeeTableRowViewModel> employees = await _dbContext.Employees
                .OrderBy(g => g.FirstName)
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

            return employees;
        }

        public async Task<EmployeeDetailsViewModel> GetEmployeeDetailsAsync(int Id)
        {
            EmployeeDetailsViewModel employee = await _dbContext.Employees
                .Where(g => g.Id == Id)
                .Select(g => new EmployeeDetailsViewModel()
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
    }
}
