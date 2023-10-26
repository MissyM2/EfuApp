using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Courses;

public interface IEditCourseUseCase
{
    Task ExecuteAsync(Course course);

}
