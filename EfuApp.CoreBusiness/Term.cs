using EfuApp.CoreBusiness.Base;
using System.ComponentModel.DataAnnotations;

namespace EfuApp.CoreBusiness;

public class Term : EntityBase
{ 

    [Required]
    [StringLength(150)]
    public string TermName { get; set; } = string.Empty;

    public string TermDesc { get; set; } = string.Empty;

    public int TermWeekCount { get; set; } = 0;

    public virtual List<WeekAssessment> WeekAssessments { get; set; } = new List<WeekAssessment>();

    public virtual List<Course> Courses { get; set; } = new List<Course>();

    


}
