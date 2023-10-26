using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Courses;

 public class EditCourseUseCase : IEditCourseUseCase
    {
        private readonly ICourseRepository courseRepository;

        public EditCourseUseCase(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task ExecuteAsync(Course course)
        {
            await this.courseRepository.UpdateCourseAsync(course);
        }

    }
