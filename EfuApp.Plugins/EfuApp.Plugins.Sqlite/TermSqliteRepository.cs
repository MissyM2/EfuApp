using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using SQLite;

namespace EfuApp.Plugins.Sqlite;

public class TermSqliteRepository : ITermRepository
{
    private SQLiteAsyncConnection database;

    public TermSqliteRepository()
    {
        this.database = new SQLiteAsyncConnection(Constants.DatabasePath);
       
        this.database.CreateTableAsync<Term>();
        Console.WriteLine("Location of db - term: " + Constants.DatabasePath);
        
        AddTermSeedData();
    }

    void AddTermSeedData()
    {
        var item1 = new Term { TermName = "Wi2023", TermDesc = "Winter, 2023"};
        var item2 = new Term { TermName = "Sp2023", TermDesc = "Spring, 2023"};
        var item3 = new Term { TermName = "Su2023", TermDesc = "Summer, 2023"};
        var item4 = new Term { TermName = "Fa2023", TermDesc = "Fall, 2023" };

        this.database.InsertAsync(item1);
        this.database.InsertAsync(item2);
        this.database.InsertAsync(item3);
        this.database.InsertAsync(item4);

    }

     public async Task<IEnumerable<Term>> GetTermsByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
                return await this.database.Table<Term>().ToListAsync();

        return await this.database.Table<Term>().Where(x => x.TermName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
    }

    public async Task AddTermAsync(Term week, string userId)
    {
        var existingItems = await this.database.Table<Term>().Where(x => x.TermName.Contains(week.TermName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        if (existingItems.Count > 0 ) return;

        await this.database.InsertAsync(week);
    }

     public async Task<Term> GetTermByIdAsync(int weekId)
    {
        return await this.database.Table<Term>().Where(x => x.TermId == weekId).FirstOrDefaultAsync();
    }

      public async Task UpdateTermAsync(Term week)
    {

        // we are not allowing two different weeks to have the same name, so we have to check to make sure

        var existingItems = await this.database.Table<Term>().Where(x => x.TermId != week.TermId && x.TermName.Contains(week.TermName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        if (existingItems.Count > 0 ) return;

        var trm = await this.database.Table<Term>().FirstOrDefaultAsync(x => x.TermId == week.TermId);
        if (trm != null)
        {
            trm.TermName = week.TermName;
            trm.TermDesc = week.TermDesc;
        }
    }

    public Task<Term> GetTermByNameAsync(string trmName)
    {
        throw new NotImplementedException();
    }
}
