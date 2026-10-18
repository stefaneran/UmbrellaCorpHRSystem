using Microsoft.AspNetCore.Mvc;
using UmbrellaCorpHRSystem.Models.ViewModels.Employees;
using UmbrellaCorpHRSystem.Services.Employees;

namespace UmbrellaCorpHRSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<EmployeeTableRowViewModel> employees = await _employeesService.GetEmployees();
            return View(employees);
        }
    }
}
