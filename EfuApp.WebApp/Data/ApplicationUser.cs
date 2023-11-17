using EfuApp.CoreBusiness;
using Microsoft.AspNetCore.Identity;

namespace EfuApp.WebApp.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string? FirstName { get; set; }

        [PersonalData]
        public string? LastName { get; set; }

        [PersonalData]
        public DateTime DOB { get; set; }

        public virtual ICollection<WeekAssessment> WeekAssessments { get; set; } = new List<WeekAssessment>();
    }
}
