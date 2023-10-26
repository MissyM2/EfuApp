using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Deliverables;

public class ViewDeliverablesByNameUseCase : IViewDeliverablesByNameUseCase
{
    private readonly IDeliverableRepository deliverableRepository;

    public ViewDeliverablesByNameUseCase(IDeliverableRepository deliverableRepository)
    {
        this.deliverableRepository = deliverableRepository;
    }

    public async Task<IEnumerable<Deliverable>> ExecuteAsync(string name = "")
    {
        return await deliverableRepository.GetDeliverablesByNameAsync(name);
    }
}
