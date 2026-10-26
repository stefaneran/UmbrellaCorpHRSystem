using System.Security.Claims;
using UmbrellaCorpHRSystem.Models.Dto.Office;
using UmbrellaCorpHRSystem.Models.ViewModels.Office;

namespace UmbrellaCorpHRSystem.Services.Office
{
    public interface IOfficeService
    {
        /// <summary>
        /// Get current status of the facillity and its departments, including the overall security status code
        /// </summary>
        /// <returns></returns>
        Task<OfficeStatusViewModel> GetOfficeStatus();

        /// <summary>
        /// Elevate currently signed-in user to Admin role
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="elevateAccessDto"></param>
        /// <returns></returns>
        Task<bool> ElevateAccessAsync(ClaimsPrincipal principal, ElevateAccessDto elevateAccessDto);

        /// <summary>
        /// Remove Admin role from currently signed-in user (Debug purposes)
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        Task<bool> DowngradeAccessAsync(ClaimsPrincipal principal);

        /// <summary>
        /// Throw pizza party to increase worker morale 
        /// </summary>
        /// <returns></returns>
        Task ThrowPizzaParty();

        /// <summary>
        /// Reset all employees' to be uninfected, alive, and with regular heartbeat
        /// </summary>
        /// <returns></returns>
        Task HealOffice();
    }
}
