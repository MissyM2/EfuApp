using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Reports
{
    public class SearchDeliverablesByCourseUseCase : ISearchDeliverablesByCourseUseCase
    {
        private readonly IDeliverableRepository deliverableRepository;

        public SearchDeliverablesByCourseUseCase(IDeliverableRepository deliverableRepository)
        {
            this.deliverableRepository = deliverableRepository;
        }

        public async Task<IEnumerable<Deliverable>> ExecuteAsync(string crsName = "")
        {
            return await deliverableRepository.GetDeliverablesByCourseNameAsync(crsName);
        }
    }
}
