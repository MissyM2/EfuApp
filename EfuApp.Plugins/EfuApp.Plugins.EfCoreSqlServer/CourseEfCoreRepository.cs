using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EfuApp.Plugins.EfCoreSqlServer;

public class CourseEFCoreRepository : ICourseRepository
{
    private readonly IDbContextFactory<EfuAppContext> contextFactory;

    public CourseEFCoreRepository(IDbContextFactory<EfuAppContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Course>> GetCoursesByNameAsync(string name)
    {
        using var db = this.contextFactory.CreateDbContext();

        return await db.Courses
            .Where(x => x.CourseName.ToLower().IndexOf(name.ToLower()) >= 0)
            .Include(course => course.Deliverables)
            .Include(course => course.Term)
            //.Include(course => course.WeekAssessments)
            .ToListAsync();
    }

    public async Task AddCourseAsync(Course course)
    {
        using var db = this.contextFactory.CreateDbContext();

        db.Courses.Add(course);
        await db.SaveChangesAsync();

    }

    public async Task<Course> GetCourseByIdAsync(int courseId)
    {
        using var db = this.contextFactory.CreateDbContext();

        var crs = await db.Courses
            .FindAsync(courseId);

        if (crs != null) return crs;

        return new Course();
    }

    public async Task UpdateCourseAsync(Course course)
    {
        using var db = this.contextFactory.CreateDbContext();

        var crs = await db.Courses.FindAsync(course.CourseId);

        if (crs != null)
        {
            crs.CourseName = course.CourseName;
            crs.CourseDesc = course.CourseDesc;

            await db.SaveChangesAsync();
        }
    }
}