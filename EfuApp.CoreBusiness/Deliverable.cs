using EfuApp.CoreBusiness.Base;
using System.ComponentModel.DataAnnotations;

namespace EfuApp.CoreBusiness;

public class Deliverable : EntityBase
{

    [Required]
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;

    [Required]
    [StringLength(150)]
    public string DeliverableName { get; set; } = string.Empty;

    public string DeliverableDesc { get; set; } = string.Empty;

    public DateTime AssignmentDate { get; set;}

    public DateTime DueDate { get; set;}

    


}
