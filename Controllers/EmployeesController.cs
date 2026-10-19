using Microsoft.AspNetCore.Mvc;
using UmbrellaCorpHRSystem.Models.Dto.Employee;
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

        public async Task<IActionResult> Index(bool CreateMode = false)
        {
            ICollection<EmployeeTableRowViewModel> employees = await _employeesService.GetEmployeesAsync();
            EmployeesIndexViewModel employeesIndexViewModel = new EmployeesIndexViewModel()
            {
                Employees = employees,
                CreateMode = CreateMode
            };
            return View(employeesIndexViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            EmployeeDetailsViewModel? employee = await _employeesService.GetEmployeeDetailsAsync(Id);

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEditEmployeeDto createEmployeeDto)
        {
            int newEmployeeId = await _employeesService.CreateEmployeeAsync(createEmployeeDto);
            return RedirectToAction(nameof(Details), new { Id = newEmployeeId });
        }
    }
}
