using System.ComponentModel.DataAnnotations;

namespace EfuApp.CoreBusiness;

public class Week
{
    public int WeekId { get; set; }

    [Required]
    [StringLength(150)]
    public string WeekName { get; set; } = string.Empty;

    public string WeekDesc { get; set; } = string.Empty;

}
