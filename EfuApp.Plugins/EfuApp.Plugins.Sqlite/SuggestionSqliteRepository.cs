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
        Console.WriteLine("Location of db - suggestion: " + Constants.DatabasePath);

        AddSuggestionSeedData();
    }

    void AddSuggestionSeedData()
    {
        var item1 = new Suggestion { SuggestionName = "Suggestion1", SuggestionDesc = "Read a book."};
        var item2 = new Suggestion { SuggestionName = "Suggestion2", SuggestionDesc = "Make a list."};
        var item3 = new Suggestion { SuggestionName = "Suggestion3", SuggestionDesc = "Take notes."};
        var item4 = new Suggestion { SuggestionName = "Suggestion4", SuggestionDesc = "Start early." };

        this.database.InsertAsync(item1);
        this.database.InsertAsync(item2);
        this.database.InsertAsync(item3);
        this.database.InsertAsync(item4);

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
       return await this.database.Table<Suggestion>().Where(x => x.Id == suggestionId).FirstOrDefaultAsync();

    }

     public async Task UpdateSuggestionAsync(Suggestion suggestion)
        {

             // we are not allowing two different suggestions to have the same name, so we have to check to make sure

            var existingItems = await this.database.Table<Suggestion>().Where(x => x.Id != suggestion.Id && x.SuggestionName.Contains(suggestion.SuggestionName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            if (existingItems.Count > 0 ) return;

             var sug = await this.database.Table<Suggestion>().FirstOrDefaultAsync(x => x.Id == suggestion.Id);
            if (sug != null)
            {
                sug.SuggestionName = suggestion.SuggestionName;
                sug.SuggestionDesc = suggestion.SuggestionDesc;
            }

            await this.database.UpdateAsync(sug);
        }
}

