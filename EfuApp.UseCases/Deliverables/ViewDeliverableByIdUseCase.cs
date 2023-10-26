using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Deliverables;

public class ViewDeliverableByIdUseCase : IViewDeliverableByIdUseCase
{
    private readonly IDeliverableRepository deliverableRepository;

    public ViewDeliverableByIdUseCase(IDeliverableRepository deliverableRepository)
    {
        this.deliverableRepository = deliverableRepository;
    }

    public async Task<Deliverable> ExecuteAsync(int deliverableId)
    {
        return await this.deliverableRepository.GetDeliverableByIdAsync(deliverableId);
    }

}
