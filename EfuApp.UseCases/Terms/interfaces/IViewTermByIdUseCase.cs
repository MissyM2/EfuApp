using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Terms;

public interface IViewTermByIdUseCase
{
    Task<Term> ExecuteAsync(int termId);

}
