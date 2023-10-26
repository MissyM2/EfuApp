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

    public Task AddCourseAsync(Course course)
    {
        if (_courses.Any(x => x.CourseName.Equals(course.CourseName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;
        
        var maxId = _courses.Max(x => x.CourseId);
        course.CourseId = maxId + 1;

        _courses.Add(course);

        return Task.CompletedTask;
    }

     public async Task<Course> GetCourseByIdAsync(int courseId)
    {
        var c = _courses.First(x => x.CourseId == courseId);
        var newCourse = new Course
        {
            CourseId = c.CourseId,
            CourseName = c.CourseName,
            CourseDesc = c.CourseDesc
        };

        return await Task.FromResult(newCourse);
    }

     public Task UpdateCourseAsync(Course course)
        {

            // we are not allowing two different courses to have the same name, so we have to check to make sure
            if (_courses.Any(x => x.CourseId != course.CourseId &&
                x.CourseName.Equals(course.CourseName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var crs = _courses.FirstOrDefault(x => x.CourseId == course.CourseId);
            if (crs != null)
            {
                crs.CourseName = course.CourseName;
                crs.CourseDesc = course.CourseDesc;
            }

            return Task.CompletedTask;
        }
}