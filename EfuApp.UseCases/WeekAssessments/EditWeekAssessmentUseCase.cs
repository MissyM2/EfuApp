using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.WeekAssessments
{
    public class EditWeekAssessmentUseCase : IEditWeekAssessmentUseCase
    {
        private readonly IWeekAssessmentRepository weekAssessmentRepository;

        public EditWeekAssessmentUseCase(IWeekAssessmentRepository weekAssessmentRepository)
        {
            this.weekAssessmentRepository = weekAssessmentRepository;
            
        }

        public async Task ExecuteAsync(WeekAssessment weekAssessment)
        {
            await this.weekAssessmentRepository.UpdateWeekAssessmentAsync(weekAssessment);
        }
    }

    
}
