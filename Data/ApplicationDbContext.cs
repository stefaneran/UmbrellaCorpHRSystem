using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UmbrellaCorpHRSystem.Data.Configurations;
using UmbrellaCorpHRSystem.Models.Email;

namespace UmbrellaCorpHRSystem.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {

        public DbSet<EmailThread> EmailThreads { get; set; } = null!;
        public DbSet<EmailMessage> EmailMessages { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmailThreadConfiguration());
            builder.ApplyConfiguration(new EmailMessageConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
