using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EfuApp.CoreBusiness;

public class Course
{
    public int CourseId { get; set; }

    [Required]
    [StringLength(150)]
    public string CourseName { get; set; } = string.Empty;

    public string CourseDesc { get; set; } = string.Empty;

    public string DaysOfWeek { get; set; } = string.Empty;
    public string Times { get; set; } = string.Empty;
    public string Instructor { get; set; } = string.Empty;


    [Required]
    public int TermId { get; set; }
    public Term Term { get; set; } = null!;

    public int WeekCount { get; set; } = 0;


    public List<Deliverable> Deliverables { get; } = new List<Deliverable>();

    public List<WeekAssessment> WeekAssessments { get; set; } = new List<WeekAssessment>();
}
