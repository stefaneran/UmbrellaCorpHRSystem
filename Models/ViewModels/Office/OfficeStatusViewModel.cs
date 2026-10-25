using UmbrellaCorpHRSystem.Models.Enums;

namespace UmbrellaCorpHRSystem.Models.ViewModels.Office
{
    public class OfficeStatusViewModel
    {
        public int NumOfEmployees { get; set; }
        public int NumOfHealthy { get; set; }
        public int NumOfInfected { get; set; }
        public int NumOfMutated { get; set; }
        public int NumOfAlive { get; set; }
        public int NumOfDeceased { get; set; }
        public bool IsManagementCompromised { get; set; }
        public bool IsBioscienceCompromised { get; set; }
        public bool IsTechnologyCompromised { get; set; }
        public bool IsProcurementCompromised { get; set; }
        public bool IsSecurityCompromised { get; set; }
        public bool IsMaintenanceCompromised { get; set; }
        public bool IsFinanceCompromised { get; set; }
        public bool IsHRCompromised { get; set; }
        public SecurityStatus SecurityStatus { get; set; }

    }
}
