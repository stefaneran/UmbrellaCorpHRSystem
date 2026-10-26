using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UmbrellaCorpHRSystem.Constants;
using UmbrellaCorpHRSystem.Data;
using UmbrellaCorpHRSystem.Models;
using UmbrellaCorpHRSystem.Models.Dto.Office;
using UmbrellaCorpHRSystem.Models.Enums;
using UmbrellaCorpHRSystem.Models.ViewModels.Office;
using UmbrellaCorpHRSystem.Services.Director;

namespace UmbrellaCorpHRSystem.Services.Office
{
    public class OfficeService : IOfficeService
    {
        private readonly UmbrellaHRSystemDbContext _dbContext;
        private readonly UserManager<HRSystemUser> _userManager;
        private readonly SignInManager<HRSystemUser> _signInManager;
        private readonly IDirectorService _directorService;
        private readonly IConfiguration _configuration;

        public OfficeService(
            UmbrellaHRSystemDbContext dbContext,
            UserManager<HRSystemUser> userManager,
            SignInManager<HRSystemUser> signInManager,
            IDirectorService directorService,
            IConfiguration configuration)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _directorService = directorService;
            _configuration = configuration;
        }

        private record EmployeeHealthStatus(Department Department, InfectionStatus InfectionStatus, LifeStatus LifeStatus);

        private bool IsDepartmentCompromised(ICollection<EmployeeHealthStatus> employees, Department department)
        {
            foreach (EmployeeHealthStatus employee in employees)
            {
                if (employee.Department == department && 
                    (employee.InfectionStatus == InfectionStatus.Infected || employee.InfectionStatus == InfectionStatus.Mutated))
                {
                    return true;
                }
            }
            return false;
        }

        private SecurityStatus GetSecurityStatus(ICollection<EmployeeHealthStatus> employees)
        {
            int numOfEmployees = employees.Count;

            int numOfHealthy = employees.Count(g => 
                (g.InfectionStatus == InfectionStatus.Uninfected) && (g.LifeStatus == LifeStatus.Alive));

            double ratio = ((double)numOfHealthy / numOfEmployees);

            if (ratio < 0.5)
            {
                return SecurityStatus.CodeRed;
            }

            return SecurityStatus.CodeGreen;
        }

        public async Task<OfficeStatusViewModel> GetOfficeStatusAsync()
        {
            ICollection<EmployeeHealthStatus> employees = await _dbContext.Employees
                .Select(g => new EmployeeHealthStatus(
                    g.Department,
                    g.InfectionStatus,
                    g.LifeStatus)
                )
                .ToListAsync();

            OfficeStatusViewModel officeStatus = new OfficeStatusViewModel()
            {
                NumOfEmployees = employees.Count,
                NumOfHealthy = employees.Count(g => g.InfectionStatus == InfectionStatus.Uninfected),
                NumOfInfected = employees.Count(g => g.InfectionStatus == InfectionStatus.Infected),
                NumOfMutated = employees.Count(g => g.InfectionStatus == InfectionStatus.Mutated),
                NumOfAlive = employees.Count(g => g.LifeStatus == LifeStatus.Alive),
                NumOfDeceased = employees.Count(g => g.LifeStatus == LifeStatus.Deceased),
                IsManagementCompromised = IsDepartmentCompromised(employees, Department.Management),
                IsBioscienceCompromised = IsDepartmentCompromised(employees, Department.Bioscience),
                IsTechnologyCompromised = IsDepartmentCompromised(employees, Department.Technology),
                IsProcurementCompromised = IsDepartmentCompromised(employees, Department.Procurement),
                IsSecurityCompromised = IsDepartmentCompromised(employees, Department.Security),
                IsMaintenanceCompromised = IsDepartmentCompromised(employees, Department.Maintenance),
                IsFinanceCompromised = IsDepartmentCompromised(employees, Department.Finance),
                IsHRCompromised = IsDepartmentCompromised(employees, Department.HR),
                SecurityStatus = GetSecurityStatus(employees)
            };

            return officeStatus;
        }

        public async Task<bool> ElevateAccessAsync(
            ClaimsPrincipal principal, 
            ElevateAccessDto elevateAccessDto)
        {
            var password = _configuration["Admin:ElevationPassword"] ?? throw new InvalidOperationException("Password not found in config");
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

        public async Task ThrowPizzaParty()
        {
            await _directorService.InitiatePizzaPartyProtocol();
        }

        public async Task HealOffice()
        {
            Random rand = new Random();
            await _dbContext.Employees
                .ExecuteUpdateAsync(g => g
                    .SetProperty(p => p.InfectionStatus, InfectionStatus.Uninfected)
                    .SetProperty(p => p.LifeStatus, LifeStatus.Alive)
                    .SetProperty(p => p.HeartRate, rand.Next(60, 80)));
        }
    }
}
