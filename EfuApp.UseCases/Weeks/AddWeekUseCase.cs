using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Weeks;

public class AddWeekUseCase : IAddWeekUseCase
{
    private readonly IWeekRepository weekRepository;

    public AddWeekUseCase(IWeekRepository weekRepository)
    {
        this.weekRepository = weekRepository;
    }

    public async Task ExecuteAsync(Week week)
    {
        await this.weekRepository.AddWeekAsync(week);
    }

}
