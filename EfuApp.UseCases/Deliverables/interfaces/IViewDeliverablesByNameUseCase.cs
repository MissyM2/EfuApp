using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Deliverables;

public interface IViewDeliverablesByNameUseCase
{
    Task<IEnumerable<Deliverable>> ExecuteAsync(string name = "");

}
