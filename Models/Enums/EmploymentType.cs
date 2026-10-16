using System.ComponentModel.DataAnnotations;

namespace UmbrellaCorpHRSystem.Models.Enums
{
    public enum EmploymentType
    {
        [Display(Name = "Full Time")]
        FullTime = 1,
        [Display(Name = "Part Time")]
        PartTime = 2,
        Contract = 3
    }
}
