using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Deliverables
{
    public class ViewDeliverablesByCourseIdUseCase : IViewDeliverablesByCourseIdUseCase
    {
        private readonly IDeliverableRepository deliverableRepository;
        public ViewDeliverablesByCourseIdUseCase(IDeliverableRepository deliverableRepository)
        {
            this.deliverableRepository = deliverableRepository;
            
        }

        public async Task<IEnumerable<Deliverable>> ExecuteAsync(int deliverableId)
        {
            return await this.deliverableRepository.GetDeliverablesByCourseIdAsync(deliverableId);
        }
    }
}
