using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using SQLite;

namespace EfuApp.Plugins.Sqlite;

public class SuggestionSqliteRepository : ISuggestionRepository
{
    private SQLiteAsyncConnection database;

    public SuggestionSqliteRepository()
    {
        this.database = new SQLiteAsyncConnection(Constants.DatabasePath);
       
        this.database.CreateTableAsync<Suggestion>();

        // _suggestions = new List<Suggestion>()
        // {
        //     new Suggestion { SuggestionId = 1, SuggestionName = "Suggestion1", SuggestionDesc = "Read a book."},
        //     new Suggestion { SuggestionId = 2, SuggestionName = "Suggestion2", SuggestionDesc = "Make a list." },
        //     new Suggestion { SuggestionId = 3, SuggestionName = "Suggestion3", SuggestionDesc = "Take notes."},
        //     new Suggestion { SuggestionId = 4, SuggestionName = "Suggestion4", SuggestionDesc = "Start early." }
        // };
    }

    public async Task<IEnumerable<Suggestion>> GetSuggestionsByNameAsync(string name)
    {
         if (string.IsNullOrWhiteSpace(name))
                return await this.database.Table<Suggestion>().ToListAsync();

        return await this.database.Table<Suggestion>().Where(x => x.SuggestionName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
    }

    public async Task AddSuggestionAsync(Suggestion suggestion)
    {
         var existingItems = await this.database.Table<Suggestion>().Where(x => x.SuggestionName.Contains(suggestion.SuggestionName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        if (existingItems.Count > 0 ) return;

        await this.database.InsertAsync(suggestion);
    }

     public async Task<Suggestion> GetSuggestionByIdAsync(int suggestionId)
    {
       return await this.database.Table<Suggestion>().Where(x => x.SuggestionId == suggestionId).FirstOrDefaultAsync();

    }

     public async Task UpdateSuggestionAsync(Suggestion suggestion)
        {

             // we are not allowing two different suggestions to have the same name, so we have to check to make sure

            var existingItems = await this.database.Table<Suggestion>().Where(x => x.SuggestionId != suggestion.SuggestionId && x.SuggestionName.Contains(suggestion.SuggestionName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            if (existingItems.Count > 0 ) return;

             var sug = await this.database.Table<Suggestion>().FirstOrDefaultAsync(x => x.SuggestionId == suggestion.SuggestionId);
            if (sug != null)
            {
                sug.SuggestionName = suggestion.SuggestionName;
                sug.SuggestionDesc = suggestion.SuggestionDesc;
            }

            await this.database.UpdateAsync(sug);
        }
}

