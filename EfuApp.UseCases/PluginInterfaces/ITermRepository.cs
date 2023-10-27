using EfuApp.CoreBusiness;

namespace EfuApp.UseCases.PluginInterfaces;

public interface ITermRepository
{
    Task<IEnumerable<Term>> GetTermsByNameAsync(string name);
    Task AddTermAsync(Term term);
    Task<Term> GetTermByIdAsync(int termId);
    Task UpdateTermAsync(Term term);

}
