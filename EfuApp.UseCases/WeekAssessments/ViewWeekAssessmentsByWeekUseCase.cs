using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.WeekAssessments
{
    public class ViewWeekAssessmentsByCourseUseCase : IViewWeekAssessmentsByCourseUseCase
    {
        private readonly IWeekAssessmentRepository weekAssessmentRepository;

        public ViewWeekAssessmentsByCourseUseCase(IWeekAssessmentRepository weekAssessmentRepository)
        {
            this.weekAssessmentRepository = weekAssessmentRepository;
        }

        public async Task<IEnumerable<WeekAssessment>> ExecuteAsync(string course = "")
        {
            return await weekAssessmentRepository.GetWeekAssessmentsByCourseNameAsync(course);
        }
    }

    
}
