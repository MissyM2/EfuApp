using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Terms;

public class ViewTermsByNameUseCase: IViewTermsByNameUseCase
{
    private readonly ITermRepository termRepository;

    public ViewTermsByNameUseCase(ITermRepository termRepository)
    {
        this.termRepository = termRepository;
    }

    public async Task<IEnumerable<Term>> ExecuteAsync(string name = "")
    {
        return await termRepository.GetTermsByNameAsync(name);
    }

}
