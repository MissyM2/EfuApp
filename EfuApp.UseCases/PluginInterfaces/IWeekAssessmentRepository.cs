using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.PluginInterfaces
{
    public interface IWeekAssessmentRepository
    {
        Task AddWeekAssessmentsAsync(Term term, int wkCount, string userId);
        Task UpdateWeekAssessmentAsync(WeekAssessment weekAssessment);
        Task<IEnumerable<WeekAssessment>> GetWeekAssessmentsByTermAsync(int trmId);
        Task<WeekAssessment> GetWeekAssessmentByIdAsync(int weekAssessmentId);
        Task<IEnumerable<WeekAssessment>> GetWeekAssessmentsByWeekNumberAsync();

    }
}




