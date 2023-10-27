using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.PluginInterfaces;

public interface ISuggestionRepository
{
    Task<IEnumerable<Suggestion>> GetSuggestionsByNameAsync(string name);
    Task AddSuggestionAsync(Suggestion suggestion);
    Task<Suggestion> GetSuggestionByIdAsync(int suggestionId);
    Task UpdateSuggestionAsync(Suggestion suggestion);

}
