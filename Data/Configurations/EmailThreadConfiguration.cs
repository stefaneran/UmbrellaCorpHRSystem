using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmbrellaCorpHRSystem.Data.Seed;
using UmbrellaCorpHRSystem.Models.Email;

namespace UmbrellaCorpHRSystem.Data.Configurations
{
    public class EmailThreadConfiguration : IEntityTypeConfiguration<EmailThread>
    {
        public void Configure(EntityTypeBuilder<EmailThread> builder)
        {
            builder.HasMany(g => g.EmailMessages)
                   .WithOne(g => g.EmailThread)
                   .HasForeignKey(g => g.EmailThreadId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(EmailSeedData.Threads);
        }
    }
}
