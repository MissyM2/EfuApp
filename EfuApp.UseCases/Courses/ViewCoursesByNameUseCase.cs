using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Courses;

public class ViewCoursesByNameUseCase : IViewCoursesByNameUseCase
{
    private readonly ICourseRepository courseRepository;

    public ViewCoursesByNameUseCase(ICourseRepository courseRepository)
    {
        this.courseRepository = courseRepository;
    }

    public async Task<IEnumerable<Course>> ExecuteAsync(string name = "")
    {
        return await courseRepository.GetCoursesByNameAsync(name);
    }

}

