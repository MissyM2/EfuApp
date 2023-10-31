using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.Plugins.Sqlite;

public class TermSqliteRepository : ITermRepository
{
    private List<Term> _courses;

    public TermSqliteRepository()
    {
        _courses = new List<Term>()
        {
            new Term { TermId = 1, TermName = "Wi2023", TermDesc = "Winter, 2023"},
            new Term { TermId = 2, TermName = "Sp2023", TermDesc = "Spring, 2023" },
            new Term { TermId = 3, TermName = "Su2023", TermDesc = "Summer, 2023"},
            new Term { TermId = 4, TermName = "Fa2023", TermDesc = "Fall, 2023" }
        };
    }

    public async Task<IEnumerable<Term>> GetTermsByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_courses);

        return _courses.Where(x => x.TermName.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public Task AddTermAsync(Term course)
    {
        if (_courses.Any(x => x.TermName.Equals(course.TermName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;
        
        var maxId = _courses.Max(x => x.TermId);
        course.TermId = maxId + 1;

        _courses.Add(course);

        return Task.CompletedTask;
    }

     public async Task<Term> GetTermByIdAsync(int courseId)
    {
        var c = _courses.First(x => x.TermId == courseId);
        var newTerm = new Term
        {
            TermId = c.TermId,
            TermName = c.TermName,
            TermDesc = c.TermDesc
        };

        return await Task.FromResult(newTerm);
    }

     public Task UpdateTermAsync(Term course)
        {

            // we are not allowing two different courses to have the same name, so we have to check to make sure
            if (_courses.Any(x => x.TermId != course.TermId &&
                x.TermName.Equals(course.TermName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var crs = _courses.FirstOrDefault(x => x.TermId == course.TermId);
            if (crs != null)
            {
                crs.TermName = course.TermName;
                crs.TermDesc = course.TermDesc;
            }

            return Task.CompletedTask;
        }

}
