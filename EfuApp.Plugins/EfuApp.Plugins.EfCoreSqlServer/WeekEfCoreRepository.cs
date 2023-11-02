using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EfuApp.Plugins.EfCoreSqlServer;

public class WeekEfCoreRepository : IWeekRepository
{
    private readonly EfuAppContext context;

    public WeekEfCoreRepository(EfuAppContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Week>> GetWeeksByNameAsync(string name)
    {
        return await context.Weeks
            .Where(x => x.WeekName.ToLower().IndexOf(name.ToLower()) >= 0)
            .Include(week => week.Term)
            .ToListAsync();
    }

    public async Task AddWeekAsync(Week week)
    {
        context.Weeks.Add(week);
        await context.SaveChangesAsync();
    }

    public async Task<Week> GetWeekByIdAsync(int weekId)
    {
        var wk = await context.Weeks.FindAsync(weekId);
        if (wk != null) return wk;

        return new Week();
    }

    public async Task UpdateWeekAsync(Week week)
    {
        var wk = await context.Weeks.FindAsync(week.WeekId);
        if (wk != null)
        {
            wk.WeekName = week.WeekName;
            wk.WeekDesc = week.WeekDesc;

            await context.SaveChangesAsync();
        }
    }
}