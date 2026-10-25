using Microsoft.AspNetCore.Identity;
using UmbrellaCorpHRSystem.Constants;
using UmbrellaCorpHRSystem.Models;

namespace UmbrellaCorpHRSystem.Data.Seed
{
    public static class IdentitySeed
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<HRSystemUser>>();
            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
            await SeedRolesAsync(roleManager);
            await SeedUsersAsync(userManager, configuration);
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(Role.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(Role.Admin));
            }
        }

        private static async Task SeedUsersAsync(UserManager<HRSystemUser> userManager, IConfiguration configuration)
        {
            string firstName = "Claire";
            string lastName = "Redfield";
            string email = $"{firstName}{lastName}@umbrellacorp.com".ToLowerInvariant();
            if (await userManager.FindByEmailAsync(email) is not null)
            {
                return;
            }
            var password = configuration["SeedUsers:ClairePassword"] ?? throw new InvalidOperationException("Password not found in config");
            var user = new HRSystemUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                FirstName = firstName,
                LastName = lastName
            };

            var result = await userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Failed to create seed user {email}: {errors}");
            }
        }

    }
}
