using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Suggestions;

public class AddSuggestionUseCase: IAddSuggestionUseCase
{
    private readonly ISuggestionRepository suggestionRepository;

    public AddSuggestionUseCase(ISuggestionRepository suggestionRepository)
    {
        this.suggestionRepository = suggestionRepository;
    }

    public async Task ExecuteAsync(Suggestion suggestion)
    {
        await this.suggestionRepository.AddSuggestionAsync(suggestion);
    }

}
