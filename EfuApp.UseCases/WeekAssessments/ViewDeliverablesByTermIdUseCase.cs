using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.WeekAssessments
{
    public class ViewWeekAssessmentsByTermIdUseCase : IViewWeekAssessmentsByTermIdUseCase
    {
        private readonly IWeekAssessmentRepository weekAssessmentRepository;
        public ViewWeekAssessmentsByTermIdUseCase(IWeekAssessmentRepository weekAssessmentRepository)
        {
            this.weekAssessmentRepository = weekAssessmentRepository;
            
        }

        public async Task<IEnumerable<WeekAssessment>> ExecuteAsync(int termId)
        {
            return await this.weekAssessmentRepository.GetWeekAssessmentsByTermIdAsync(termId);
        }
    }
}
