using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmbrellaCorpHRSystem.Data.Seed;
using UmbrellaCorpHRSystem.Models.Entities.Email;

namespace UmbrellaCorpHRSystem.Data.Configurations
{
    public class EmailMessageConfiguration : IEntityTypeConfiguration<EmailMessage>
    {
        public void Configure(EntityTypeBuilder<EmailMessage> builder)
        {
            builder.HasData(EmailSeedData.Messages);
        }
    }
}
