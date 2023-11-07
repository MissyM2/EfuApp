using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.PluginInterfaces;

public interface IDeliverableRepository
{
    Task<IEnumerable<Deliverable>> GetDeliverablesByNameAsync(string name);
    Task AddDeliverableAsync(Deliverable course);
    Task<Deliverable> GetDeliverableByIdAsync(int courseId);
    Task UpdateDeliverableAsync(Deliverable course);
     Task<IEnumerable<Deliverable>> GetDeliverablesByDateAsync(string name);
    Task<IEnumerable<Deliverable>> GetDeliverablesByCourseNameAsync(string crsName);

}
