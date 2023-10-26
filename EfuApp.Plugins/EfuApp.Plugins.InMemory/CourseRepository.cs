using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.Plugins.InMemory;

public class CourseRepository : ICourseRepository
{
    private List<Course> _courses;

    public CourseRepository()
    {
        _courses = new List<Course>()
        {
            new Course { CourseId = 1, CourseName = "English 101", CourseDesc = "A course on English"},
            new Course { CourseId = 2, CourseName = "Math 101", CourseDesc = "A course on Math" },
            new Course { CourseId = 3, CourseName = "Psych 101", CourseDesc = "A course on Psychology"},
            new Course { CourseId = 4, CourseName = "Soc 101", CourseDesc = "A course on Sociology" }
        };
    }

    public async Task<IEnumerable<Course>> GetCoursesByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_courses);

        return _courses.Where(x => x.CourseName.Contains(name, StringComparison.OrdinalIgnoreCase));
    }
}