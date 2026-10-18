using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmbrellaCorpHRSystem.Data.Seed;
using UmbrellaCorpHRSystem.Models.Employee;

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
