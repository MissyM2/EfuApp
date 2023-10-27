using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Suggestions;

public interface IViewSuggestionByIdUseCase
{
    Task<Suggestion> ExecuteAsync(int suggestionId);

}
