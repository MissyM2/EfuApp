using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Deliverables;

public interface IAddDeliverableUseCase
{
    Task ExecuteAsync(Deliverable deliverable);

}
