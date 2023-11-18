using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.PluginInterfaces
{
    public interface IWeekAssessmentRepository
    {
        Task AddWeekAssessmentAsync(WeekAssessment weekAssessment);
        Task UpdateWeekAssessmentAsync(WeekAssessment weekAssessment);
        Task<IEnumerable<WeekAssessment>> GetWeekAssessmentsByTermAsync(string trmName);
        Task<WeekAssessment> GetWeekAssessmentByIdAsync(int weekAssessmentId);
        Task<IEnumerable<WeekAssessment>> GetWeekAssessmentsByWeekNumberAsync();

    }
}




