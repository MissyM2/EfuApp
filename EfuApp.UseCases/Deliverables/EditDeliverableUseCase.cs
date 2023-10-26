using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Deliverables;

public class EditDeliverableUseCase : IEditDeliverableUseCase
{
    private readonly IDeliverableRepository deliverableRepository;

    public EditDeliverableUseCase(IDeliverableRepository deliverableRepository)
    {
        this.deliverableRepository = deliverableRepository;
    }
    public async Task ExecuteAsync(Deliverable deliverable)
        {
            await this.deliverableRepository.UpdateDeliverableAsync(deliverable);
        }


}
