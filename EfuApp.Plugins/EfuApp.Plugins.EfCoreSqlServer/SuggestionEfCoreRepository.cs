using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EfuApp.Plugins.EfCoreSqlServer;

public class SuggestionEfCoreRepository : ISuggestionRepository
{
    private readonly IDbContextFactory<EfuAppContext> contextFactory;

    public SuggestionEfCoreRepository(IDbContextFactory<EfuAppContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }

    public async Task AddSuggestionAsync(Suggestion suggestion)
    {
        using var db = this.contextFactory.CreateDbContext();

        db.Suggestions.Add(suggestion);
        await db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Suggestion>> GetSuggestionsByNameAsync(string name)
    {
        using var db = this.contextFactory.CreateDbContext();

        return await db.Suggestions.Where(
            x => x.SuggestionName.ToLower().IndexOf(name.ToLower()) >= 0).ToListAsync();
    }

    public async Task<Suggestion> GetSuggestionByIdAsync(int suggestionId)
    {
        using var db = this.contextFactory.CreateDbContext();

        var sug = await db.Suggestions.FindAsync(suggestionId);
        if (sug != null) return sug;

        return new Suggestion();
    }

    public async Task UpdateSuggestionAsync(Suggestion suggestion)
    {
        using var db = this.contextFactory.CreateDbContext();

        var sug = await db.Suggestions.FindAsync(suggestion.Id);
        if (sug != null)
        {
            sug.SuggestionName = suggestion.SuggestionName;
            sug.SuggestionDesc = suggestion.SuggestionDesc;

            await db.SaveChangesAsync();
        }
    }
}
