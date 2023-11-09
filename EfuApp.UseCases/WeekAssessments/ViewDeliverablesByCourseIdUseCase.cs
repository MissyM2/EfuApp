using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.WeekAssessments
{
    public class ViewWeekAssessmentsByCourseIdUseCase : IViewWeekAssessmentsByCourseIdUseCase
    {
        private readonly IWeekAssessmentRepository weekAssessmentRepository;
        public ViewWeekAssessmentsByCourseIdUseCase(IWeekAssessmentRepository weekAssessmentRepository)
        {
            this.weekAssessmentRepository = weekAssessmentRepository;
            
        }

        public async Task<IEnumerable<WeekAssessment>> ExecuteAsync(int courseId)
        {
            return await this.weekAssessmentRepository.GetWeekAssessmentsByCourseIdAsync(courseId);
        }
    }
}
