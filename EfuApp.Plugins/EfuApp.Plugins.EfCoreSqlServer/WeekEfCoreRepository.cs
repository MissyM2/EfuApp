using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EfuApp.Plugins.EfCoreSqlServer;

public class WeekEfCoreRepository : IWeekRepository
{
    private readonly IDbContextFactory<EfuAppContext> contextFactory;

    public WeekEfCoreRepository(IDbContextFactory<EfuAppContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Week>> GetWeeksByNameAsync(string name)
    {
        using var db = this.contextFactory.CreateDbContext();

        return await db.Weeks
            .Where(x => x.WeekName.ToLower().IndexOf(name.ToLower()) >= 0)
            .Include(week => week.Term)
            .ToListAsync();
    }

    public async Task AddWeekAsync(Week week)
    {
        using var db = this.contextFactory.CreateDbContext();

        db.Weeks.Add(week);
        await db.SaveChangesAsync();
    }

    public async Task<Week> GetWeekByIdAsync(int weekId)
    {
        using var db = this.contextFactory.CreateDbContext();

        var wk = await db.Weeks.FindAsync(weekId);
        if (wk != null) return wk;

        return new Week();
    }

    public async Task UpdateWeekAsync(Week week)
    {
        using var db = this.contextFactory.CreateDbContext();

        var wk = await db.Weeks.FindAsync(week.WeekId);
        if (wk != null)
        {
            wk.WeekName = week.WeekName;
            wk.WeekDesc = week.WeekDesc;

            await db.SaveChangesAsync();
        }
    }
}