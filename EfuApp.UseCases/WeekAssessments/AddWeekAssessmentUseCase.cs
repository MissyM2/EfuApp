using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.WeekAssessments
{
    public class AddWeekAssessmentsUseCase : IAddWeekAssessmentsUseCase
    {
        private readonly IWeekAssessmentRepository weekAssessmentRepository;
        public AddWeekAssessmentsUseCase(IWeekAssessmentRepository weekAssessmentRepository)
        {
            this.weekAssessmentRepository = weekAssessmentRepository;
        }

        public async Task ExecuteAsync(Term term, int wkCount, string userId)
        {
            await this.weekAssessmentRepository.AddWeekAssessmentsAsync(term, wkCount, userId);
        }
    }
}
