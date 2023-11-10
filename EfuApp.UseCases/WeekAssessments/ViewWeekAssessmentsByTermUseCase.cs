using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.WeekAssessments
{
    public class ViewWeekAssessmentsByTermUseCase : IViewWeekAssessmentsByTermUseCase
    {
        private readonly IWeekAssessmentRepository weekAssessmentRepository;

        public ViewWeekAssessmentsByTermUseCase(IWeekAssessmentRepository weekAssessmentRepository)
        {
            this.weekAssessmentRepository = weekAssessmentRepository;
        }

        public async Task<IEnumerable<WeekAssessment>> ExecuteAsync(string term = "")
        {
            return await weekAssessmentRepository.GetWeekAssessmentsByTermNameAsync(term);
        }
    }

    
}
