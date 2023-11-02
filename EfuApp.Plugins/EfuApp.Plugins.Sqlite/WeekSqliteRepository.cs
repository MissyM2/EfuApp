using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using SQLite;

namespace EfuApp.Plugins.Sqlite;

public class WeekSqliteRepository : IWeekRepository
{
    private SQLiteAsyncConnection database;

    public WeekSqliteRepository()
    {
        this.database = new SQLiteAsyncConnection(Constants.DatabasePath);
       
        this.database.CreateTableAsync<Week>();

        Console.WriteLine("Location of db - week: " + Constants.DatabasePath);

        AddWeekSeedData();
    }

    void AddWeekSeedData()
    {
        var item1 = new Week { WeekName = "1", WeekDesc = "first week of semester"};
        var item2 = new Week { WeekName = "2", WeekDesc = "second week of semester"};
        var item3 = new Week { WeekName = "3", WeekDesc = "third week of semester"};
        var item4 = new Week { WeekName = "4", WeekDesc = "fourth week of semester" };

        this.database.InsertAsync(item1);
        this.database.InsertAsync(item2);
        this.database.InsertAsync(item3);
        this.database.InsertAsync(item4);

    }

    public async Task<IEnumerable<Week>> GetWeeksByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
                return await this.database.Table<Week>().ToListAsync();

        return await this.database.Table<Week>().Where(x => x.WeekName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
    }

    public async Task AddWeekAsync(Week week)
    {
        var existingItems = await this.database.Table<Week>().Where(x => x.WeekName.Contains(week.WeekName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        if (existingItems.Count > 0 ) return;

        await this.database.InsertAsync(week);
    }

     public async Task<Week> GetWeekByIdAsync(int weekId)
    {
        return await this.database.Table<Week>().Where(x => x.WeekId == weekId).FirstOrDefaultAsync();
    }

     public async Task UpdateWeekAsync(Week week)
    {

        // we are not allowing two different weeks to have the same name, so we have to check to make sure

        var existingItems = await this.database.Table<Week>().Where(x => x.WeekId != week.WeekId && x.WeekName.Contains(week.WeekName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        if (existingItems.Count > 0 ) return;

            var wk = await this.database.Table<Week>().FirstOrDefaultAsync(x => x.WeekId == week.WeekId);
        if (wk != null)
        {
            wk.WeekName = week.WeekName;
            wk.WeekDesc = week.WeekDesc;
            wk.WeekId = week.WeekId;
            wk.LikedMost = week.LikedMost;
            wk.LikedLeast = week.LikedMost;
            wk.MostDifficult = week.MostDifficult;
            wk.LeastDifficult = week.LeastDifficult;
        }
    }

}

