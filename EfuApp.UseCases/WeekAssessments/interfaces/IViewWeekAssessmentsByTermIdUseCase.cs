using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.WeekAssessments
{
    public interface IViewWeekAssessmentsByTermIdUseCase
    {
        Task<IEnumerable<WeekAssessment>> ExecuteAsync(int termId);
    }
}