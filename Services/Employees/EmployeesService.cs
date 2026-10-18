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

        public async Task<ICollection<EmployeeTableRowViewModel>> GetEmployees()
        {
            ICollection<EmployeeTableRowViewModel> employees = await _dbContext.Employees
                .Select(g => new EmployeeTableRowViewModel()
                {
                    Name = $"{g.FirstName} {g.LastName}",
                })
                .ToListAsync();

            return employees;
        }
    }
}
