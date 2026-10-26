using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmbrellaCorpHRSystem.Constants;
using UmbrellaCorpHRSystem.Models.Dto.Office;
using UmbrellaCorpHRSystem.Models.ViewModels.Office;
using UmbrellaCorpHRSystem.Services.Office;

namespace UmbrellaCorpHRSystem.Controllers
{
    [Authorize]
    public class OfficeController : Controller
    {
        private readonly IOfficeService _officeService;

        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            OfficeStatusViewModel officeStatus = await _officeService.GetOfficeStatus();
            return View(officeStatus);
        }

        [HttpGet]
        public IActionResult ElevateAccessView()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ElevateAccess(ElevateAccessDto elevateAccessDto)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(ElevateAccessView), elevateAccessDto);
            }

            bool success = await _officeService.ElevateAccessAsync(User, elevateAccessDto);
            if (!success)
            {
                ModelState.AddModelError(nameof(ElevateAccessDto.Password), "ACCESS DENIED: UNAUTHORIZED CODE");
                return View(nameof(ElevateAccessView), elevateAccessDto);
            }

            return RedirectToAction("Index", "Office");
        }

        /// <summary>
        /// Downgrades user access from Admin to User - Debug purposes
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> DowngradeAccess()
        {
            await _officeService.DowngradeAccessAsync(User);
            return RedirectToAction("Index", "Office");
        }

        [HttpPost]
        public async Task<IActionResult> ThrowPizzaParty()
        {
            await _officeService.ThrowPizzaParty();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> InitiateSelfDestructProtocol()
        {
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Resets the health status of all employees in the office so we can see CodeGreen status again - Debug purposes
        /// </summary>
        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> HealOffice()
        {
            await _officeService.HealOffice();
            return RedirectToAction(nameof(Index));
        }
    }
}
