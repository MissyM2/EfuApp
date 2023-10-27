using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Suggestions;

public class ViewSuggestionsByNameUseCase:IViewSuggestionsByNameUseCase
{
    private readonly ISuggestionRepository suggestionRepository;

    public ViewSuggestionsByNameUseCase(ISuggestionRepository suggestionRepository)
    {
        this.suggestionRepository = suggestionRepository;
    }

    public async Task<IEnumerable<Suggestion>> ExecuteAsync(string name = "")
    {
        return await suggestionRepository.GetSuggestionsByNameAsync(name);
    }

}
