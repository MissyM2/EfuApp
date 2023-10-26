using System.ComponentModel.DataAnnotations;

namespace EfuApp.CoreBusiness;

public class Deliverable
{
    public int DeliverableId { get; set; }

    [Required]
    [StringLength(150)]
    public string DeliverableName { get; set; } = string.Empty;

    public string DeliverableDesc { get; set; } = string.Empty;

    public DateTime AssignmentDate {get; set;}

    public DateTime DueDate {get; set;}

}
