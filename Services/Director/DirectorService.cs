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
        private string automatedEmail = "automated@umbrellacorp.com";
        private string albertWeskerEmail = "albertwesker@umbrellacorp.com";
        private string claireRedfieldEmail = "claireredfield@umbrellacorp.com";

        public DirectorService(UmbrellaHRSystemDbContext dbContext, UserManager<HRSystemUser> userManager)
        {
            _dbContext = dbContext;
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

        public async Task InitiateSelfDestruct()
        {
            await _dbContext.Employees
                .ExecuteUpdateAsync(g => g
                    .SetProperty(p => p.LifeStatus, LifeStatus.Deceased)
                    .SetProperty(p => p.HeartRate, 0)
                    .SetProperty(p => p.EmploymentStatus, EmploymentStatus.Terminated));

            EmailThread newEmailThread = new EmailThread()
            {
                SenderEmail = automatedEmail,
                RecipientEmail = claireRedfieldEmail,
                EmailMessages =
                {
                    new EmailMessage()
                    {
                        SenderEmail = automatedEmail,
                        RecipientEmail = claireRedfieldEmail,
                        Subject = "FACILITY PURGED",
                        Body = """
                        Dear Employee,

                        This is an automated message to notify employees that the facility has been purged. 
                        If any items have been left in the fridge during the self destruct protocol, consider them forfeit. 

                        Have a wonderful day,
                        Umbrella Automated Email System
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
