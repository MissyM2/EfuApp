using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Deliverables;

public interface IEditDeliverableUseCase
{
    Task ExecuteAsync(Deliverable deliverable);

}
