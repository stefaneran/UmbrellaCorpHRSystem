using System.Security.Claims;
using UmbrellaCorpHRSystem.Models.Dto.Admin;
using UmbrellaCorpHRSystem.Models.ViewModels.Admin;

namespace UmbrellaCorpHRSystem.Services.Admin
{
    public interface IAdminService
    {
        Task<OfficeStatusViewModel> GetOfficeStatus();
        Task<bool> ElevateAccessAsync(ClaimsPrincipal principal, ElevateAccessDto elevateAccessDto);
        Task<bool> DowngradeAccessAsync(ClaimsPrincipal principal);
        Task ThrowPizzaParty();
        Task HealOffice();
    }
}
