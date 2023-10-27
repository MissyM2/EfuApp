using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Terms;

public interface IEditTermUseCase
{
    Task ExecuteAsync(Term term);

}
