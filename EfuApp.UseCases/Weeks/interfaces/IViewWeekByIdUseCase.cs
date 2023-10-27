using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.Weeks;

public interface IViewWeekByIdUseCase
{
    Task<Week> ExecuteAsync(int weekId);

}
