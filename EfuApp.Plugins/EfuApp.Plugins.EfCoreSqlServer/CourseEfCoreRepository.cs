using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EfuApp.Plugins.EfCoreSqlServer;

public class CourseEFCoreRepository : ICourseRepository
{
    private readonly EfuAppContext context;

    public CourseEFCoreRepository(EfuAppContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Course>> GetCoursesByNameAsync(string name)
    {
        return await context.Courses
            .Where(x => x.CourseName.ToLower().IndexOf(name.ToLower()) >= 0)
            .Include(course => course.Deliverables)
            .ToListAsync();
    }

    public async Task AddCourseAsync(Course course)
    {
        context.Courses.Add(course);
        await context.SaveChangesAsync();
    }

    public async Task<Course> GetCourseByIdAsync(int courseId)
    {
        var crs = await context.Courses.FindAsync(courseId);
        if (crs != null) return crs;

        return new Course();
    }

    public async Task UpdateCourseAsync(Course course)
    {
        var crs = await context.Courses.FindAsync(course.CourseId);
        if (crs != null)
        {
            crs.CourseName = course.CourseName;
            crs.CourseDesc = course.CourseDesc;

            await context.SaveChangesAsync();
        }
    }
}