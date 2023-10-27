using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Weeks;

public interface IEditWeekUseCase
{
    Task ExecuteAsync(Week week);

}
