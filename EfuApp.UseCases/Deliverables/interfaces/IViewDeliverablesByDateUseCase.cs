using EfuApp.CoreBusiness;

namespace EfuApp.UseCases;

public interface IViewDeliverablesByDateUseCase
{
    Task<IEnumerable<Deliverable>> ExecuteAsync(string name = "");
}
