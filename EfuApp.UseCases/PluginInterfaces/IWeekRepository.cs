using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.PluginInterfaces;

public interface IWeekRepository
{
    Task<IEnumerable<Week>> GetWeeksByNameAsync(string name);
    Task AddWeekAsync(Week week);
    Task<Week> GetWeekByIdAsync(int weekId);
    Task UpdateWeekAsync(Week week);

}
