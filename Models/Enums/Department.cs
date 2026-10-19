using System.ComponentModel.DataAnnotations;

namespace UmbrellaCorpHRSystem.Models.Enums
{
    public enum Department
    {
        Management = 1,
        Bioscience = 2,
        Technology = 3,
        Procurement = 4,
        Security = 5,
        Maintenance = 6,
        Finance = 7,
        [Display(Name = "Human Resources")]
        HR = 8
    }

    public static class DepartmentExtension
    {
        private static readonly string[] MaintenanceLocations =
        [
            "Boiler Room",
            "Ventilation Shafts",
            "Lobby",
            "Corridor A",
            "Corridor B",
            "Corridor C"
        ];
        private static readonly string[] FacillityLocations =
        [
            "Lobby",
            "Corridor A",
            "Corridor B",
            "Corridor C",
            "Executive Offices",
            "Administrative Office",
            "Accounting Office",
            "IT Room",
            "Labs",
            "Security Room"
        ];
        public static string GetDefaultLocation(this Department department) 
        {
            if (department == Department.Management)
            {
                return "Executive Offices";
            }
            if (department == Department.HR)
            {
                return "Administrative Office";
            }
            if (department == Department.Finance)
            {
                return "Accounting Office";
            }
            if (department == Department.Technology)
            {
                return "IT Room";
            }
            if (department == Department.Bioscience)
            {
                return "Labs";
            }
            if (department == Department.Procurement)
            {
                return "Out of Site";
            }
            if (department == Department.Maintenance)
            {
                Random rand = new Random();
                return MaintenanceLocations[rand.Next(MaintenanceLocations.Length)];
            }
            if (department == Department.Security)
            {
                Random rand = new Random();
                return FacillityLocations[rand.Next(FacillityLocations.Length)];
            }
            return "Error";
        }
    }
}
