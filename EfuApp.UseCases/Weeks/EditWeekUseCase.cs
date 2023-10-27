using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Weeks;

public class EditWeekUseCase: IEditWeekUseCase
{
    private readonly IWeekRepository weekRepository;

        public EditWeekUseCase(IWeekRepository weekRepository)
        {
            this.weekRepository = weekRepository;
        }

        public async Task ExecuteAsync(Week week)
        {
            await this.weekRepository.UpdateWeekAsync(week);
        }

}
