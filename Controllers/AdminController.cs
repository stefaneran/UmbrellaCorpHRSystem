using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UmbrellaCorpHRSystem.Models;
using UmbrellaCorpHRSystem.Models.Dto.Admin;
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

        public IActionResult Index()
        {
            return View();
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

        public async Task<IActionResult> DowngradeAccess()
        {
            bool success = await _adminService.DowngradeAccessAsync(User);
            if (!success)
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
