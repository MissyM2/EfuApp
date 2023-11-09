using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.WeekAssessments
{
    public interface IEditWeekAssessmentUseCase
    {
        Task ExecuteAsync(WeekAssessment weekAssessment);
    }
}
