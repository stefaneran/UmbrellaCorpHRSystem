using Microsoft.AspNetCore.Mvc;
using UmbrellaCorpHRSystem.Models.Dto.Admin;
using UmbrellaCorpHRSystem.Models.ViewModels.Admin;
using UmbrellaCorpHRSystem.Services.Admin;

namespace UmbrellaCorpHRSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> Index()
        {
            OfficeStatusViewModel officeStatus = await _adminService.GetOfficeStatus();
            return View(officeStatus);
        }

        public IActionResult ElevateAccessView()
        {
            return View();
        }

        public async Task<IActionResult> ElevateAccess(ElevateAccessDto elevateAccessDto)
        {
            bool success = await _adminService.ElevateAccessAsync(User, elevateAccessDto);
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Downgrades user access from Admin to User - Debug purposes
        /// </summary>
        public async Task<IActionResult> DowngradeAccess()
        {
            bool success = await _adminService.DowngradeAccessAsync(User);
            if (!success)
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ThrowPizzaParty()
        {
            await _adminService.ThrowPizzaParty();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> InitiateSelfDestructProtocol()
        {
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Resets the health status of all employees in the office so we can see CodeGreen status again - Debug purposes
        /// </summary>
        public async Task<IActionResult> HealOffice()
        {
            await _adminService.HealOffice();
            return RedirectToAction(nameof(Index));
        }
    }
}
