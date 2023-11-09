using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Deliverables
{
    public interface IViewDeliverablesByCourseIdUseCase
    {
        Task<IEnumerable<Deliverable>> ExecuteAsync(int deliverableId);
    }
}
