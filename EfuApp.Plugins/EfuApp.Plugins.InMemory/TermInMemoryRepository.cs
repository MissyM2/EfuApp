using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.Plugins.InMemory;

public class TermInMemoryRepository : ITermRepository
{
    private List<Term> _courses;

    public TermInMemoryRepository()
    {
        _courses = new List<Term>()
        {
            new Term { Id = 1, TermName = "Wi2023", TermDesc = "Winter, 2023"},
            new Term { Id = 2, TermName = "Sp2023", TermDesc = "Spring, 2023" },
            new Term { Id = 3, TermName = "Su2023", TermDesc = "Summer, 2023"},
            new Term { Id = 4, TermName = "Fa2023", TermDesc = "Fall, 2023" }
        };
    }

    public async Task<IEnumerable<Term>> GetTermsByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_courses);

        return _courses.Where(x => x.TermName.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public Task AddTermAsync(Term course, string userId)
    {
        if (_courses.Any(x => x.TermName.Equals(course.TermName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;
        
        var maxId = _courses.Max(x => x.Id);
        course.Id = maxId + 1;

        _courses.Add(course);

        return Task.CompletedTask;
    }

     public async Task<Term> GetTermByIdAsync(int courseId)
    {
        var c = _courses.First(x => x.Id == courseId);
        var newTerm = new Term
        {
            Id = c.Id,
            TermName = c.TermName,
            TermDesc = c.TermDesc
        };

        return await Task.FromResult(newTerm);
    }

     public Task UpdateTermAsync(Term course)
        {

            // we are not allowing two different courses to have the same name, so we have to check to make sure
            if (_courses.Any(x => x.Id != course.Id &&
                x.TermName.Equals(course.TermName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var crs = _courses.FirstOrDefault(x => x.Id == course.Id);
            if (crs != null)
            {
                crs.TermName = course.TermName;
                crs.TermDesc = course.TermDesc;
            }

            return Task.CompletedTask;
        }

    public Task<Term> GetTermByNameAsync(string trmName)
    {
        throw new NotImplementedException();
    }
}
