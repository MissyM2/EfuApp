using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Terms;

public interface IAddTermUseCase
{
    Task ExecuteAsync(Term term, string userId);

}
