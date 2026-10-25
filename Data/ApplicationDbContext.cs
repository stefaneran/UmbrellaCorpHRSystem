using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UmbrellaCorpHRSystem.Data.Configurations;
using UmbrellaCorpHRSystem.Models;
using UmbrellaCorpHRSystem.Models.Entities.Email;
using UmbrellaCorpHRSystem.Models.Entities.Employees;

namespace UmbrellaCorpHRSystem.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<HRSystemUser>(options)
    {

        public DbSet<EmailThread> EmailThreads { get; set; } = null!;
        public DbSet<EmailMessage> EmailMessages { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmailThreadConfiguration());
            builder.ApplyConfiguration(new EmailMessageConfiguration());
            builder.ApplyConfiguration(new EmployeesConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
