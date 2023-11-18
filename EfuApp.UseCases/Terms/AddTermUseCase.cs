using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Terms;

public class AddTermUseCase : IAddTermUseCase
{
    private readonly ITermRepository termRepository;

    public AddTermUseCase(ITermRepository termRepository)
    {
        this.termRepository = termRepository;
    }

    public async Task ExecuteAsync(Term term)
    {
        await this.termRepository.AddTermAsync(term);
    }

}
