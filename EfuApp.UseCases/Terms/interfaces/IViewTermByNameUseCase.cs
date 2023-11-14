using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Terms
{
    public interface IViewTermByNameUseCase
    {
        Task<Term> ExecuteAsync(string trmName);
    }
}