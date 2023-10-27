using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Weeks;

public class ViewWeekByIdUseCase: IViewWeekByIdUseCase
{
     private readonly IWeekRepository weekRepository;

        public ViewWeekByIdUseCase(IWeekRepository weekRepository)
        {
            this.weekRepository = weekRepository;
        }
        public async Task<Week> ExecuteAsync(int weekId)
        {
            return await this.weekRepository.GetWeekByIdAsync(weekId);
        }

}
