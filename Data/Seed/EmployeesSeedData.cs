using UmbrellaCorpHRSystem.Models.Enums;
using UmbrellaCorpHRSystem.Models.Employee;

namespace UmbrellaCorpHRSystem.Data.Seed
{
    public static class EmployeesSeedData
    {
        public static Employee[] Employees =>
        [
            new Employee()
            {
                Id = 1,
                FirstName = "Albert",
                LastName = "Wesker",
                Email = "albertwesker@umbrellacorp.com",
                Salary = 384000,
                TotalAnnualLeave = 32,
                UsedAnnualLeave = 1,
                Department = Department.Management,
                EmploymentStatus = EmploymentStatus.Employed,
                EmploymentType = EmploymentType.FullTime,
                HeartRate = 65,
                CurrentLocation = "Executive Offices",
                InfectionStatus = InfectionStatus.Uninfected,
                LifeStatus = LifeStatus.Alive
            },
            new Employee()
            {
                Id = 2,
                FirstName = "James",
                LastName = "Marcus",
                Email = "jamesmarcus@umbrellacorp.com",
                Salary = 326000,
                TotalAnnualLeave = 30,
                UsedAnnualLeave = 3,
                Department = Department.Management,
                EmploymentStatus = EmploymentStatus.Employed,
                EmploymentType = EmploymentType.FullTime,
                HeartRate = 66,
                CurrentLocation = "Executive Offices",
                InfectionStatus = InfectionStatus.Uninfected,
                LifeStatus = LifeStatus.Alive
            },
            new Employee()
            {
                Id = 3,
                FirstName = "Claire",
                LastName = "Redfield",
                Email = "claireredfield@umbrellacorp.com",
                Salary = 84000,
                TotalAnnualLeave = 22,
                UsedAnnualLeave = 0,
                Department = Department.HR,
                EmploymentStatus = EmploymentStatus.Employed,
                EmploymentType = EmploymentType.FullTime,
                HeartRate = 121,
                CurrentLocation = "Administrative Office",
                InfectionStatus = InfectionStatus.Infected,
                LifeStatus = LifeStatus.Alive
            }
        ];
    }
}
