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

        public async Task<IActionResult> Index(bool createMode = false)
        {
            ICollection<EmployeeTableRowViewModel> employees = await _employeesService.GetEmployeesAsync();
            EmployeesIndexViewModel employeesIndexViewModel = new EmployeesIndexViewModel()
            {
                Employees = employees,
                CreateMode = createMode
            };
            return View(employeesIndexViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, bool editMode = false)
        {
            var employee = await _employeesService.GetEmployeeDetailsAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            EmployeeDetailsViewModel employeeDetailsViewModel = new EmployeeDetailsViewModel()
            {
                Id = id,
                EmployeeInfo = employee,
                EditMode = editMode
            };
            if (editMode)
            {
                var employeeDto = await _employeesService.GetEmployeeForEditAsync(id);
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

        [HttpGet]
        public IActionResult DeleteEmployeeConfirmation(int id, string name)
        {
            return View(new DeleteEmployeeConfirmationViewModel()
            {
                Id = id,
                Name = name
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            bool success = await _employeesService.DeleteEmployeeAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
