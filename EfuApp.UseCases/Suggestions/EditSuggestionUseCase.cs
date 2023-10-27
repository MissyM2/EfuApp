using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Suggestions;

public class EditSuggestionUseCase: IEditSuggestionUseCase
{
    private readonly ISuggestionRepository suggestionRepository;

        public EditSuggestionUseCase(ISuggestionRepository suggestionRepository)
        {
            this.suggestionRepository = suggestionRepository;
        }

        public async Task ExecuteAsync(Suggestion suggestion)
        {
            await this.suggestionRepository.UpdateSuggestionAsync(suggestion);
        }

}
