using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Reports
{
    public interface ISearchDeliverablesByCourseUseCase
    {
        Task<IEnumerable<Deliverable>> ExecuteAsync(string crsName);
    }
}