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
        Task<OfficeStatusViewModel> GetOfficeStatusAsync();

        /// <summary>
        /// Elevate currently signed-in user to Admin role
        /// </summary>
        Task<bool> ElevateAccessAsync(ClaimsPrincipal principal, ElevateAccessDto elevateAccessDto);

        /// <summary>
        /// Remove Admin role from currently signed-in user (Debug purposes)
        /// </summary>
        Task<bool> DowngradeAccessAsync(ClaimsPrincipal principal);

        /// <summary>
        /// Throw pizza party to increase worker morale 
        /// </summary>
        Task ThrowPizzaParty();

        /// <summary>
        /// Reset all employees' to be uninfected, alive, and with regular heartbeat
        /// </summary>
        Task HealOffice();

        /// <summary>
        /// Initiate the Self Destruct Protocol after the last confirmation is done
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="selfDestructDto"></param>
        /// <returns></returns>
        Task<bool> InitiateSelfDestruct(ClaimsPrincipal principal, ElevateAccessDto selfDestructDto);
    }
}
