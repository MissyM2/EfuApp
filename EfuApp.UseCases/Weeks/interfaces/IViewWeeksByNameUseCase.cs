using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Weeks;

public interface IViewWeeksByNameUseCase
{
    Task<IEnumerable<Week>> ExecuteAsync(string name = "");

}
