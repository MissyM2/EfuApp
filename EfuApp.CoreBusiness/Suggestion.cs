using EfuApp.CoreBusiness.Base;
using System.ComponentModel.DataAnnotations;

namespace EfuApp.CoreBusiness;

public class Suggestion : EntityBase
{

    [Required]
    [StringLength(150)]
    public string SuggestionName { get; set; } = string.Empty;

    public string SuggestionDesc { get; set; } = string.Empty;

}
