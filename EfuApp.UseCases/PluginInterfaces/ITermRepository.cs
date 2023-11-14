using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.PluginInterfaces;

public interface ITermRepository
{
    Task<IEnumerable<Term>> GetTermsByNameAsync(string name);
    Task AddTermAsync(Term term, string userId);
    Task<Term> GetTermByIdAsync(int termId);
    Task UpdateTermAsync(Term term);

}
