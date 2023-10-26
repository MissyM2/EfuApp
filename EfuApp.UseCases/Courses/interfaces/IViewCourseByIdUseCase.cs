using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Courses;

public interface IViewCourseByIdUseCase
{
    Task<Course> ExecuteAsync(int courseId);

}