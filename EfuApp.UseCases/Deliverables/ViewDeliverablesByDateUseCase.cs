using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Deliverables;

public class ViewDeliverablesByDateUseCase : IViewDeliverablesByDateUseCase
{
    private readonly IDeliverableRepository deliverableRepository;

    public ViewDeliverablesByDateUseCase(IDeliverableRepository deliverableRepository)
    {
        this.deliverableRepository = deliverableRepository;
    }

    public async Task<IEnumerable<Deliverable>> ExecuteAsync(string name = "")
    {
        return await deliverableRepository.GetDeliverablesByDateAsync(name);
    }

}
