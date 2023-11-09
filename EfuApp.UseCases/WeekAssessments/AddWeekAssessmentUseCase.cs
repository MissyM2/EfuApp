using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.WeekAssessments
{
    public class AddWeekAssessmentUseCase : IAddWeekAssessmentUseCase
    {
        private readonly IWeekAssessmentRepository weekAssessmentRepository;
        public AddWeekAssessmentUseCase(IWeekAssessmentRepository weekAssessmentRepository)
        {
            this.weekAssessmentRepository = weekAssessmentRepository;
        }

        public async Task ExecuteAsync(WeekAssessment weekAssessment)
        {
            await this.weekAssessmentRepository.AddWeekAssessmentAsync(weekAssessment);
        }
    }
}
