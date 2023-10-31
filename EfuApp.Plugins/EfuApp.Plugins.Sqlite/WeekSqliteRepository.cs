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

        // _weeks = new List<Week>()
        // {
        //     new Week { WeekId = 1, WeekName = "1", WeekDesc = "first week of semester"},
        //     new Week { WeekId = 2, WeekName = "2", WeekDesc = "second week of semester" },
        //     new Week { WeekId = 3, WeekName = "3", WeekDesc = "third week of semester"},
        //     new Week { WeekId = 4, WeekName = "4", WeekDesc = "fourth week of semester" }
        // };
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
            wk.TermId = week.TermId;
            wk.LikedMost = week.LikedMost;
            wk.LikedLeast = week.LikedMost;
            wk.MostDifficult = week.MostDifficult;
            wk.LeastDifficult = week.LeastDifficult;
        }
    }

}

