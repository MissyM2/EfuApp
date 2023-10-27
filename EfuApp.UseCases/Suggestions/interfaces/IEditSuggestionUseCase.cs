using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Suggestions;

public interface IEditSuggestionUseCase
{
    Task ExecuteAsync(Suggestion suggestion);

}
