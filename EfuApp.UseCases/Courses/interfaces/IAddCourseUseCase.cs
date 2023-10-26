using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Courses;

public interface IAddCourseUseCase
{
    Task ExecuteAsync(Course course);

}
