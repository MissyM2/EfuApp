using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.Plugins.InMemory;

public class WeekRepository : IWeekRepository
{
    private List<Week> _courses;

    public WeekRepository()
    {
        _courses = new List<Week>()
        {
            new Week { WeekId = 1, WeekName = "1", WeekDesc = "first week of semester"},
            new Week { WeekId = 2, WeekName = "2", WeekDesc = "second week of semester" },
            new Week { WeekId = 3, WeekName = "3", WeekDesc = "third week of semester"},
            new Week { WeekId = 4, WeekName = "4", WeekDesc = "fourth week of semester" }
        };
    }

    public async Task<IEnumerable<Week>> GetWeeksByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_courses);

        return _courses.Where(x => x.WeekName.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public Task AddWeekAsync(Week course)
    {
        if (_courses.Any(x => x.WeekName.Equals(course.WeekName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;
        
        var maxId = _courses.Max(x => x.WeekId);
        course.WeekId = maxId + 1;

        _courses.Add(course);

        return Task.CompletedTask;
    }

     public async Task<Week> GetWeekByIdAsync(int courseId)
    {
        var c = _courses.First(x => x.WeekId == courseId);
        var newWeek = new Week
        {
            WeekId = c.WeekId,
            WeekName = c.WeekName,
            WeekDesc = c.WeekDesc
        };

        return await Task.FromResult(newWeek);
    }

     public Task UpdateWeekAsync(Week course)
        {

            // we are not allowing two different courses to have the same name, so we have to check to make sure
            if (_courses.Any(x => x.WeekId != course.WeekId &&
                x.WeekName.Equals(course.WeekName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var crs = _courses.FirstOrDefault(x => x.WeekId == course.WeekId);
            if (crs != null)
            {
                crs.WeekName = course.WeekName;
                crs.WeekDesc = course.WeekDesc;
            }

            return Task.CompletedTask;
        }

}
