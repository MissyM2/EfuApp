using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Courses;

public class AddCourseUseCase : IAddCourseUseCase
{
    private readonly ICourseRepository courseRepository;

    public AddCourseUseCase(ICourseRepository courseRepository)
    {
        this.courseRepository = courseRepository;
    }

    public async Task ExecuteAsync(Course course)
    {
        await this.courseRepository.AddCourseAsync(course);
    }

}
