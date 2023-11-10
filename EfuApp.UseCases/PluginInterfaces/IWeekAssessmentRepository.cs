using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.PluginInterfaces
{
    public interface IWeekAssessmentRepository
    {
        Task AddWeekAssessmentAsync(WeekAssessment weekAssessment);
        Task UpdateWeekAssessmentAsync(WeekAssessment weekAssessment);
        Task<IEnumerable<WeekAssessment>> GetWeekAssessmentsByTermNameAsync(string trmName);
        Task<IEnumerable<WeekAssessment>> GetWeekAssessmentsByTermIdAsync(int trmId);

    }
}




