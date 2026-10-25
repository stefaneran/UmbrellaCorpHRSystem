using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmbrellaCorpHRSystem.Data.Seed;
using UmbrellaCorpHRSystem.Models.Entities.Employees;

namespace UmbrellaCorpHRSystem.Data.Configurations
{
    public class EmployeesConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(EmployeesSeedData.Employees);
        }
    }
}
