using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.PluginInterfaces
{
    public interface IWeekAssessmentRepository
    {
        Task AddWeekAssessmentAsync(WeekAssessment weekAssessment);
        Task UpdateWeekAssessmentAsync(WeekAssessment weekAssessment);
        Task<IEnumerable<WeekAssessment>> GetWeekAssessmentsByCourseNameAsync(string crsName);
        Task<IEnumerable<WeekAssessment>> GetWeekAssessmentsByCourseIdAsync(int courseId);

    }
}




