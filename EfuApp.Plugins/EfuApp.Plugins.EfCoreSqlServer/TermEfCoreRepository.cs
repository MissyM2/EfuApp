using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EfuApp.Plugins.EfCoreSqlServer;

public class TermEfCoreRepository : ITermRepository
{
    private readonly IDbContextFactory<EfuAppContext> contextFactory;

    public TermEfCoreRepository(IDbContextFactory<EfuAppContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Term>> GetTermsByNameAsync(string name)
    {
        using var db = this.contextFactory.CreateDbContext();

        return await db.Terms
            .Where(x => x.TermName.ToLower().IndexOf(name.ToLower()) >= 0)
            .Include(term => term.Weeks)
            .ToListAsync();
    }

    public async Task AddTermAsync(Term term)
    {
        using var db = this.contextFactory.CreateDbContext();

        db.Terms.Add(term);
        await db.SaveChangesAsync();
    }

    public async Task<Term> GetTermByIdAsync(int termId)
    {
        using var db = this.contextFactory.CreateDbContext();

        var trm = await db.Terms.FindAsync(termId);
        if (trm != null) return trm;

        return new Term();
    }

    public async Task UpdateTermAsync(Term term)
    {
        using var db = this.contextFactory.CreateDbContext();

        var trm = await db.Terms.FindAsync(term.TermId);
        if (trm != null)
        {
            trm.TermName = term.TermName;
            trm.TermDesc = term.TermDesc;

            await db.SaveChangesAsync();
        }
    }
}