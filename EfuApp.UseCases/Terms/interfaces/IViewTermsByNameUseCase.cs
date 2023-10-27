using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Terms;

public interface IViewTermsByNameUseCase
{
    Task<IEnumerable<Term>> ExecuteAsync(string name = "");

}
