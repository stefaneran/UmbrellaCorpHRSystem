using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UmbrellaCorpHRSystem.Data;
using UmbrellaCorpHRSystem.Models;
using UmbrellaCorpHRSystem.Models.Entities.Email;
using UmbrellaCorpHRSystem.Models.Enums;

namespace UmbrellaCorpHRSystem.Services.Director
{
    public class DirectorService : IDirectorService
    {
        private readonly UmbrellaHRSystemDbContext _dbContext;
        private readonly UserManager<HRSystemUser> _userManager;
        private string albertWeskerEmail = "albertwesker@umbrellacorp.com";
        private string claireRedfieldEmail = "claireredfield@umbrellacorp.com";

        public DirectorService(UmbrellaHRSystemDbContext dbContext, UserManager<HRSystemUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitiatePizzaPartyProtocol()
        {

            // Infect people
            int numOfPeopletoInfect = 55;
            Random rand = new Random();
            List<int> healthyEmployees = await _dbContext.Employees
                .Where(g => g.InfectionStatus == InfectionStatus.Uninfected)
                .Select(g => g.Id)
                .ToListAsync();
            List<int> employeesToBeInfected = healthyEmployees
                .OrderBy(g => rand.Next())
                .Take(numOfPeopletoInfect)
                .ToList();
            await _dbContext.Employees
                .Where(g => employeesToBeInfected.Contains(g.Id))
                .ExecuteUpdateAsync(g => g
                    .SetProperty(p => p.InfectionStatus, InfectionStatus.Infected)
                    .SetProperty(p => p.HeartRate, rand.Next(110, 160)));

            // Send an email from Wesker
            EmailThread newEmailThread = new EmailThread()
            {
                SenderEmail = albertWeskerEmail,
                RecipientEmail = claireRedfieldEmail,
                EmailMessages =
                {
                    new EmailMessage()
                    {
                        SenderEmail = albertWeskerEmail,
                        RecipientEmail = claireRedfieldEmail,
                        Subject = "CLAIRE URGENT READ ASAP",
                        Body = """
                        claire the pizza party was a terrible idea, i am getting alerts that the t virus broke containement and several employes are affected, I need you to tkae control of the office as admin quickly and intervene, go to the elevate access page and type the passowrd: ARKLAYPROTOCOL immediatelly!!!

                        this will grant you access to take the necessary measures
                        """,
                        SentDate = DateTime.UtcNow
                    }
                }
            };
            _dbContext.EmailThreads.Add(newEmailThread);
            await _dbContext.SaveChangesAsync();
        }
    }
}
