using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Terms;

public class ViewTermByNameUseCase : IViewTermByNameUseCase
{

    private readonly ITermRepository TermRepository;

    public ViewTermByNameUseCase(ITermRepository TermRepository)
    {
        this.TermRepository = TermRepository;
    }
    public async Task<Term> ExecuteAsync(string trmName)
    {
        return await this.TermRepository.GetTermByNameAsync(trmName);
    }

}
