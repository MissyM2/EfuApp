using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.WeekAssessments
{
    public interface IViewWeekAssessmentsByCourseIdUseCase
    {
        Task<IEnumerable<WeekAssessment>> ExecuteAsync(int courseId);
    }
}