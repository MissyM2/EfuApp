using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using SQLite;

namespace EfuApp.Plugins.Sqlite;

public class CourseSqliteRepository : ICourseRepository
{
    private SQLiteAsyncConnection database;

    public CourseSqliteRepository()
    {
        this.database = new SQLiteAsyncConnection(Constants.DatabasePath);
       
        this.database.CreateTableAsync<Course>();

        // _courses = new List<Course>()
        // {
        //     new Course { CourseId = 1, CourseName = "English 101", CourseDesc = "A course on English"},
        //     new Course { CourseId = 2, CourseName = "Math 101", CourseDesc = "A course on Math" },
        //     new Course { CourseId = 3, CourseName = "Psych 101", CourseDesc = "A course on Psychology"},
        //     new Course { CourseId = 4, CourseName = "Soc 101", CourseDesc = "A course on Sociology" }
        // };
    }

    public async Task<IEnumerable<Course>> GetCoursesByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
                return await this.database.Table<Course>().ToListAsync();

        return await this.database.Table<Course>().Where(x => x.CourseName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
    }

    public async Task AddCourseAsync(Course course)
    {
        var existingItems = await this.database.Table<Course>().Where(x => x.CourseName.Contains(course.CourseName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        if (existingItems.Count > 0 ) return;

        await this.database.InsertAsync(course);
    }

     public async Task<Course> GetCourseByIdAsync(int courseId)
    {

        return await this.database.Table<Course>().Where(x => x.CourseId == courseId).FirstOrDefaultAsync();
    }

     public async Task UpdateCourseAsync(Course course)
        {

            // we are not allowing two different courses to have the same name, so we have to check to make sure

            var existingItems = await this.database.Table<Course>().Where(x => x.CourseId != course.CourseId && x.CourseName.Contains(course.CourseName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            if (existingItems.Count > 0 ) return;

             var crs = await this.database.Table<Course>().FirstOrDefaultAsync(x => x.CourseId == course.CourseId);
            if (crs != null)
            {
                crs.CourseName = course.CourseName;
                crs.CourseDesc = course.CourseDesc;
            }

            await this.database.UpdateAsync(crs);
        }
}
