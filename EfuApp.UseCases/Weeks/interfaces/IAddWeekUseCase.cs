using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Weeks;

public interface IAddWeekUseCase
{
    Task ExecuteAsync(Week week);

}
