using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.Plugins.InMemory;

public class CourseInMemoryRepository : ICourseRepository
{
    private List<Course> _courses;

    public CourseInMemoryRepository()
    {
        _courses = new List<Course>()
        {
            new Course { Id = 1, CourseName = "English 101", CourseDesc = "A course on English"},
            new Course { Id = 2, CourseName = "Math 101", CourseDesc = "A course on Math" },
            new Course { Id = 3, CourseName = "Psych 101", CourseDesc = "A course on Psychology"},
            new Course { Id = 4, CourseName = "Soc 101", CourseDesc = "A course on Sociology" }
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
        
        var maxId = _courses.Max(x => x.Id);
        course.Id = maxId + 1;

        _courses.Add(course);

        return Task.CompletedTask;
    }

     public async Task<Course> GetCourseByIdAsync(int courseId)
    {
        var c = _courses.First(x => x.Id == courseId);
        var newCourse = new Course
        {
            Id = c.Id,
            CourseName = c.CourseName,
            CourseDesc = c.CourseDesc
        };

        return await Task.FromResult(newCourse);
    }

     public Task UpdateCourseAsync(Course course)
        {

            // we are not allowing two different courses to have the same name, so we have to check to make sure
            if (_courses.Any(x => x.Id != course.Id &&
                x.CourseName.Equals(course.CourseName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var crs = _courses.FirstOrDefault(x => x.Id == course.Id);
            if (crs != null)
            {
                crs.CourseName = course.CourseName;
                crs.CourseDesc = course.CourseDesc;
            }

            return Task.CompletedTask;
        }
}