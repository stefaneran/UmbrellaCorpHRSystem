using System.Security.Claims;
using UmbrellaCorpHRSystem.Models.Dto.Office;
using UmbrellaCorpHRSystem.Models.ViewModels.Office;

namespace UmbrellaCorpHRSystem.Services.Office
{
    public interface IOfficeService
    {
        Task<OfficeStatusViewModel> GetOfficeStatus();
        Task<bool> ElevateAccessAsync(ClaimsPrincipal principal, ElevateAccessDto elevateAccessDto);
        Task<bool> DowngradeAccessAsync(ClaimsPrincipal principal);
        Task ThrowPizzaParty();
        Task HealOffice();
    }
}
