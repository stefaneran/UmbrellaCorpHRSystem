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
            ICollection<EmployeeTableRowViewModel> employees = await _employeesService.GetEmployeesAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            EmployeeDetailsViewModel employee = await _employeesService.GetEmployeeDetailsAsync(Id);
            return View(employee);
        }
    }
}
