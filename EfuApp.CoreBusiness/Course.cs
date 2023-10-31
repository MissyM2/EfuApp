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

    // [Required]
    // public int TermId {get; set;}
    // public Term? Term {get; set; }

    

    public List<Deliverable> Deliverables { get; set; } = new List<Deliverable>();
}
