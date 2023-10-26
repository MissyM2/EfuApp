using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Deliverables;

public interface IViewDeliverableByIdUseCase
{
    Task<Deliverable> ExecuteAsync(int deliverableId);

}
