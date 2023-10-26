using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Courses;

public class ViewCourseByIdUseCase : IViewCourseByIdUseCase
    {
        private readonly ICourseRepository courseRepository;

        public ViewCourseByIdUseCase(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public async Task<Course> ExecuteAsync(int courseId)
        {
            return await this.courseRepository.GetCourseByIdAsync(courseId);
        }
    }
