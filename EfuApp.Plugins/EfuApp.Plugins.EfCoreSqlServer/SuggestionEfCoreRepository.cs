using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EfuApp.Plugins.EfCoreSqlServer;

public class SuggestionEfCoreRepository : ISuggestionRepository
{
    private readonly EfuAppContext context;

    public SuggestionEfCoreRepository(EfuAppContext context)
    {
        this.context = context;
    }

    public async Task AddSuggestionAsync(Suggestion suggestion)
    {
        //using var context = this.contextFactory.CreateDbContext();
        context.Suggestions.Add(suggestion);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Suggestion>> GetSuggestionsByNameAsync(string name)
    {
        //using var context = this.contextFactory.CreateDbContext();
        return await context.Suggestions.Where(
            x => x.SuggestionName.ToLower().IndexOf(name.ToLower()) >= 0).ToListAsync();
    }

    public async Task<Suggestion> GetSuggestionByIdAsync(int suggestionId)
    {
        //using var context = this.contextFactory.CreateDbContext();
        var sug = await context.Suggestions.FindAsync(suggestionId);
        if (sug != null) return sug;

        return new Suggestion();
    }

    public async Task UpdateSuggestionAsync(Suggestion suggestion)
    {
        //using var context = this.contextFactory.CreateDbContext();
        var sug = await context.Suggestions.FindAsync(suggestion.SuggestionId);
        if (sug != null)
        {
            sug.SuggestionName = suggestion.SuggestionName;
            sug.SuggestionDesc = suggestion.SuggestionDesc;

            await context.SaveChangesAsync();
        }
    }
}
