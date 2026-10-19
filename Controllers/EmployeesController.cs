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
        public async Task<IActionResult> Details(int Id, bool EditMode = false)
        {
            var employee = await _employeesService.GetEmployeeDetailsAsync(Id);
            if (employee == null)
            {
                return NotFound();
            }
            EmployeeDetailsViewModel employeeDetailsViewModel = new EmployeeDetailsViewModel()
            {
                EmployeeInfo = employee,
                EditMode = EditMode
            };
            if (EditMode)
            {
                var employeeDto = await _employeesService.GetEmployeeForEditAsync(Id);
                if (employeeDto == null)
                {
                    return NotFound();
                }
                employeeDetailsViewModel.EmployeeDto = employeeDto;
            }
            return View(employeeDetailsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEditEmployeeDto createEmployeeDto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            int newEmployeeId = await _employeesService.CreateEmployeeAsync(createEmployeeDto);
            return RedirectToAction(nameof(Details), new { Id = newEmployeeId });
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(CreateEditEmployeeDto editEmployeeDto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            bool success = await _employeesService.EditEmployeeAsync(editEmployeeDto);
            if (!success)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Details), new { editEmployeeDto.Id });
        }
    }
}
