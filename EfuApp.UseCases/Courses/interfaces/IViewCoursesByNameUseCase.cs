using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Courses;

public interface IViewCoursesByNameUseCase
{
     Task<IEnumerable<Course>> ExecuteAsync(string name = "");

}
