using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Terms;

public class ViewTermByIdUseCase:IViewTermByIdUseCase
{
     private readonly ITermRepository TermRepository;

        public ViewTermByIdUseCase(ITermRepository TermRepository)
        {
            this.TermRepository = TermRepository;
        }
        public async Task<Term> ExecuteAsync(int TermId)
        {
            return await this.TermRepository.GetTermByIdAsync(TermId);
        }

}
