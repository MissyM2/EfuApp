using System.ComponentModel.DataAnnotations;

namespace EfuApp.CoreBusiness;

public class Suggestion
{
    public int SuggestionId { get; set; }

    [Required]
    [StringLength(150)]
    public string SuggestionName { get; set; } = string.Empty;

    public string SuggestionDesc { get; set; } = string.Empty;

}
