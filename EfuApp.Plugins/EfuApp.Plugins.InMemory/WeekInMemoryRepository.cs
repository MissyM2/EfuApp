using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.Plugins.InMemory;

public class WeekInMemoryRepository : IWeekRepository
{
    private List<Week> _weeks;

    public WeekInMemoryRepository()
    {
        _weeks = new List<Week>()
        {
            new Week { WeekId = 1, WeekName = "1", WeekDesc = "first week of semester"},
            new Week { WeekId = 2, WeekName = "2", WeekDesc = "second week of semester" },
            new Week { WeekId = 3, WeekName = "3", WeekDesc = "third week of semester"},
            new Week { WeekId = 4, WeekName = "4", WeekDesc = "fourth week of semester" }
        };
    }

    public async Task<IEnumerable<Week>> GetWeeksByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_weeks);

        return _weeks.Where(x => x.WeekName.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public Task AddWeekAsync(Week week)
    {
        if (_weeks.Any(x => x.WeekName.Equals(week.WeekName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;
        
        var maxId = _weeks.Max(x => x.WeekId);
        week.WeekId = maxId + 1;

        _weeks.Add(week);

        return Task.CompletedTask;
    }

     public async Task<Week> GetWeekByIdAsync(int weekId)
    {
        var c = _weeks.First(x => x.WeekId == weekId);
        var newWeek = new Week
        {
            WeekId = c.WeekId,
            WeekName = c.WeekName,
            WeekDesc = c.WeekDesc,
            TermId = c.TermId,
            LikedMost = c.LikedMost,
            LikedLeast = c.LikedMost,
            MostDifficult = c.MostDifficult,
            LeastDifficult = c.LeastDifficult,
        };

        return await Task.FromResult(newWeek);
    }

     public Task UpdateWeekAsync(Week week)
        {

            // we are not allowing two different weeks to have the same name, so we have to check to make sure
            if (_weeks.Any(x => x.WeekId != week.WeekId &&
                x.WeekName.Equals(week.WeekName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var crs = _weeks.FirstOrDefault(x => x.WeekId == week.WeekId);
            if (crs != null)
            {
                crs.WeekName = week.WeekName;
                crs.WeekDesc = week.WeekDesc;
                crs.TermId = week.TermId;
                crs.LikedMost = week.LikedMost;
                crs.LikedLeast = week.LikedMost;
                crs.MostDifficult = week.MostDifficult;
                crs.LeastDifficult = week.LeastDifficult;
            }

            return Task.CompletedTask;
        }

}
