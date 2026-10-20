using System.Security.Claims;
using UmbrellaCorpHRSystem.Models.Dto.Admin;

namespace UmbrellaCorpHRSystem.Services.Admin
{
    public interface IAdminService
    {
        Task<bool> ElevateAccessAsync(ClaimsPrincipal principal, ElevateAccessDto elevateAccessDto);
        Task<bool> DowngradeAccessAsync(ClaimsPrincipal principal);
    }
}
