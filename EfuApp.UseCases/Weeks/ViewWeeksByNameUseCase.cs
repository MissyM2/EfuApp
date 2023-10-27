using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Weeks;

public class ViewWeeksByNameUseCase: IViewWeeksByNameUseCase
{
    private readonly IWeekRepository weekRepository;

    public ViewWeeksByNameUseCase(IWeekRepository weekRepository)
    {
        this.weekRepository = weekRepository;
    }

    public async Task<IEnumerable<Week>> ExecuteAsync(string name = "")
    {
        return await weekRepository.GetWeeksByNameAsync(name);
    }

}
