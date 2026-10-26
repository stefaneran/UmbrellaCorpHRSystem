using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmbrellaCorpHRSystem.Models.Dto.Employee;
using UmbrellaCorpHRSystem.Models.ViewModels.Employees;
using UmbrellaCorpHRSystem.Services.Employees;

namespace UmbrellaCorpHRSystem.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, bool createMode = false)
        {
            EmployeesIndexViewModel employeesIndexViewModel = new EmployeesIndexViewModel()
            {
                CreateMode = createMode
            };

            if (!createMode)
            {
                EmployeeTableViewModel employeeTable = await _employeesService.GetEmployeesAsync(page);
                employeesIndexViewModel.CurrentPage = page;
                employeesIndexViewModel.EmployeeTable = employeeTable;
            }

            return View(employeesIndexViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, bool editMode = false)
        {
            EmployeeDetailsViewModel employeeDetailsViewModel = new EmployeeDetailsViewModel()
            {
                Id = id,
                EditMode = editMode
            };

            if (!editMode)
            {
                var employee = await _employeesService.GetEmployeeDetailsAsync(id);

                if (employee == null)
                {
                    return NotFound();
                }

                employeeDetailsViewModel.EmployeeInfo = employee;
            }
            else
            {
                var employeeDto = await _employeesService.GetEmployeeForEditAsync(id);

                if (employeeDto == null)
                {
                    return NotFound();
                }

                employeeDetailsViewModel.EditEmployeeDto = employeeDto;
            }

            return View(employeeDetailsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEditEmployeeDto createEmployeeDto)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Index), new EmployeesIndexViewModel()
                {
                    CreateMode = true,
                    CreateEmployeeDto = createEmployeeDto
                });
            }

            int newEmployeeId = await _employeesService.CreateEmployeeAsync(createEmployeeDto);

            return RedirectToAction(nameof(Details), new { Id = newEmployeeId });
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(CreateEditEmployeeDto editEmployeeDto)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Details), new EmployeeDetailsViewModel()
                {
                    Id = editEmployeeDto.Id,
                    EditMode = true,
                    EditEmployeeDto = editEmployeeDto
                });
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
