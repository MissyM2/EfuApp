using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.WeekAssessments
{
    public class ViewWeekAssessmentByIdUseCase : IViewWeekAssessmentByIdUseCase
    {
        private readonly IWeekAssessmentRepository weekAssessmentRepository;
        public ViewWeekAssessmentByIdUseCase(IWeekAssessmentRepository weekAssessmentRepository)
        {
            this.weekAssessmentRepository = weekAssessmentRepository;
            
        }

        public async Task<WeekAssessment> ExecuteAsync(int weekAssessmentId)
        {
            return await this.weekAssessmentRepository.GetWeekAssessmentByIdAsync(weekAssessmentId);
        }
    }
}
