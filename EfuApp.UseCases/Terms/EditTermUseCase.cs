using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.UseCases.Terms;

public class EditTermUseCase: IEditTermUseCase
{
    private readonly ITermRepository termRepository;

        public EditTermUseCase(ITermRepository termRepository)
        {
            this.termRepository = termRepository;
        }

        public async Task ExecuteAsync(Term term)
        {
            await this.termRepository.UpdateTermAsync(term);
        }

}
