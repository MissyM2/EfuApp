using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.PluginInterfaces;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetCoursesByNameAsync(string name);
    Task AddCourseAsync(Course course);
    Task<Course> GetCourseByIdAsync(int courseId);
    Task UpdateCourseAsync(Course course);

}
