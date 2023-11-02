using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EfuApp.Plugins.EfCoreSqlServer;

public class TermEfCoreRepository : ITermRepository
{
    private readonly EfuAppContext context;

    public TermEfCoreRepository(EfuAppContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Term>> GetTermsByNameAsync(string name)
    {
        return await context.Terms
            .Where(x => x.TermName.ToLower().IndexOf(name.ToLower()) >= 0)
            .Include(term => term.Weeks)
            .ToListAsync();
    }

    public async Task AddTermAsync(Term term)
    {
        context.Terms.Add(term);
        await context.SaveChangesAsync();
    }

    public async Task<Term> GetTermByIdAsync(int termId)
    {
        var trm = await context.Terms.FindAsync(termId);
        if (trm != null) return trm;

        return new Term();
    }

    public async Task UpdateTermAsync(Term term)
    {
        var trm = await context.Terms.FindAsync(term.TermId);
        if (trm != null)
        {
            trm.TermName = term.TermName;
            trm.TermDesc = term.TermDesc;

            await context.SaveChangesAsync();
        }
    }
}