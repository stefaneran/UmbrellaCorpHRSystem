using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmbrellaCorpHRSystem.Models.Email;
using UmbrellaCorpHRSystem.Data.Seed;

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
