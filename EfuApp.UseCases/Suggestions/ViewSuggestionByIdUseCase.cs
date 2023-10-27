using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Suggestions;

public class ViewSuggestionByIdUseCase:IViewSuggestionByIdUseCase
{
     private readonly ISuggestionRepository suggestionRepository;

        public ViewSuggestionByIdUseCase(ISuggestionRepository suggestionRepository)
        {
            this.suggestionRepository = suggestionRepository;
        }
        public async Task<Suggestion> ExecuteAsync(int suggestionId)
        {
            return await this.suggestionRepository.GetSuggestionByIdAsync(suggestionId);
        }

}
