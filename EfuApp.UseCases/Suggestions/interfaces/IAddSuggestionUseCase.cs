using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Suggestions;

public interface IAddSuggestionUseCase
{
    Task ExecuteAsync(Suggestion suggestion);

}
