using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.WeekAssessments
{
    public interface IViewWeekAssessmentByIdUseCase
    {
        Task<WeekAssessment> ExecuteAsync(int weekAssessmentId);
    }
}