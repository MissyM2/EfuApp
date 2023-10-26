using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.PluginInterfaces;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetCoursesByNameAsync(string name);
    Task AddCourseAsync(Course course);

}
