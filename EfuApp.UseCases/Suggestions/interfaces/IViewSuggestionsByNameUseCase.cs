using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Suggestions;

public interface IViewSuggestionsByNameUseCase
{
    Task<IEnumerable<Suggestion>> ExecuteAsync(string name = "");

}
