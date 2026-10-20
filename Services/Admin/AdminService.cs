using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using UmbrellaCorpHRSystem.Constants;
using UmbrellaCorpHRSystem.Models;
using UmbrellaCorpHRSystem.Models.Dto.Admin;

namespace UmbrellaCorpHRSystem.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<HRSystemUser> _userManager;
        private readonly SignInManager<HRSystemUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AdminService(
            UserManager<HRSystemUser> userManager,
            SignInManager<HRSystemUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        public async Task<bool> ElevateAccessAsync(
            ClaimsPrincipal principal, 
            ElevateAccessDto elevateAccessDto)
        {
            var password = _configuration["Admin:ElevationPassword"] ?? throw new InvalidOperationException("Password not found in secrets");
            if (password != elevateAccessDto.Password)
            {
                return false;
            }
            var user = await _userManager.GetUserAsync(principal);
            if (user == null)
            {
                return false;
            }
            IdentityResult identityResult = await _userManager.AddToRoleAsync(user, Role.Admin);
            if (!identityResult.Succeeded)
            {
                return false;
            }
            await _signInManager.RefreshSignInAsync(user);
            return true;
        }

        public async Task<bool> DowngradeAccessAsync(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            if (user == null)
            {
                return false;
            }
            IdentityResult identityResult = await _userManager.RemoveFromRoleAsync(user, Role.Admin);
            if (!identityResult.Succeeded)
            {
                return false;
            }
            await _signInManager.RefreshSignInAsync(user);
            return true;
        }
    }
}
