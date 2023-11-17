using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using SQLite;

namespace EfuApp.Plugins.Sqlite;

public class CourseSqliteRepository : ICourseRepository
{
    private SQLiteAsyncConnection _dbConnection;

    // public CourseSqliteRepository()
    // {
    //     SetUpDb();
    // }

     private async void SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EfuAppSqliteDb.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath, Constants.Flags);
                await _dbConnection.CreateTableAsync<Course>();

                // try
                // {
                //     await _dbConnection.CreateTableAsync<Course>();

                //     var rowCount = await _dbConnection.Table<Course>().CountAsync();
                //     if (rowCount == 0)
                //     {
                //         AddCourseSeedData();
                //     }
                // }
                // catch (Exception ex)
                // {
                //     Console.WriteLine("CreateDatabase " + ex.Message.ToString());
                // }
            }
        }


    void AddCourseSeedData()
    {
        var item1 = new Course { Id = 1, CourseName = "English 101", CourseDesc = "A course on English"};
        var item2 = new Course { Id = 2, CourseName = "Math 101", CourseDesc = "A course on Math" };
        var item3 = new Course { Id = 3, CourseName = "Psych 101", CourseDesc = "A course on Psychology"};
        var item4 = new Course { Id = 4, CourseName = "Soc 101", CourseDesc = "A course on Sociology" };

        _dbConnection.InsertAsync(item1);
        _dbConnection.InsertAsync(item2);
        _dbConnection.InsertAsync(item3);
        _dbConnection.InsertAsync(item4);

    }

    public async Task<IEnumerable<Course>> GetCoursesByNameAsync(string name)
    {
        SetUpDb();

        // if (string.IsNullOrWhiteSpace(name))
        //         return await _dbConnection.Table<Course>().ToListAsync();

        return await _dbConnection.Table<Course>().Where(x => x.CourseName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
    }

    public async Task AddCourseAsync(Course course)
    {

        var existingItems = await _dbConnection.Table<Course>().Where(x => x.CourseName.Contains(course.CourseName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        if (existingItems.Count > 0 ) return;

        await _dbConnection.InsertAsync(course);
    }

     public async Task<Course> GetCourseByIdAsync(int courseId)
    {

        return await _dbConnection.Table<Course>().Where(x => x.Id == courseId).FirstOrDefaultAsync();
    }

     public async Task UpdateCourseAsync(Course course)
    {

        // we are not allowing two different courses to have the same name, so we have to check to make sure

        var existingItems = await _dbConnection.Table<Course>().Where(x => x.Id != course.Id && x.CourseName.Contains(course.CourseName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        if (existingItems.Count > 0 ) return;

            var crs = await _dbConnection.Table<Course>().FirstOrDefaultAsync(x => x.Id == course.Id);
        if (crs != null)
        {
            crs.CourseName = course.CourseName;
            crs.CourseDesc = course.CourseDesc;
        }

        await _dbConnection.UpdateAsync(crs);
    }
}
