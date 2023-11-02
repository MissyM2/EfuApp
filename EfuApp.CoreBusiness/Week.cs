using System.ComponentModel.DataAnnotations;

namespace EfuApp.CoreBusiness;

public class Week
{
    public int WeekId { get; set; }

    [Required]
    [StringLength(150)]
    public string WeekName { get; set; } = string.Empty;

    public string WeekDesc { get; set; } = string.Empty;
    public int TermId { get; set; }
    public Term Term { get; set; } = null!;
    public string LikedLeast { get; set; } = string.Empty;
    public string LikedMost { get; set; } = string.Empty;
    public string MostDifficult { get; set; } = string.Empty;
    public string LeastDifficult { get; set; } = string.Empty;




}
