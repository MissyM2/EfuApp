using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Deliverables;

public class AddDeliverableUseCase : IAddDeliverableUseCase
{
    private readonly IDeliverableRepository deliverableRepository;
    public AddDeliverableUseCase(IDeliverableRepository deliverableRepository)
    {
        this.deliverableRepository = deliverableRepository;
        
    }

    public async Task ExecuteAsync(Deliverable deliverable)
    {
        await this.deliverableRepository.AddDeliverableAsync(deliverable);
    }

}
