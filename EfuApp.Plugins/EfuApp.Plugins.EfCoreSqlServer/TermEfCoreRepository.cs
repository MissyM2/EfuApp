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
            .ToListAsync();
    }

    public async Task AddTermAsync(Term term, string userId)
    {
        using var db = this.contextFactory.CreateDbContext();

        db.Terms.Add(term);
        await db.SaveChangesAsync();

        int newTermId = term.TermId;
        int wkCount = term.TermWeekCount;

        for (int i = 1; i <= term.TermWeekCount; i++)
        {
            db.WeekAssessments.Add(new WeekAssessment
            {
                TermId = term.TermId,
                Term = term,
                WeekNumber = i,
                LikedLeast = "",
                LikedMost = "",
                MostDifficult = "",
                LeastDifficult = "",
                UserId = userId
            });

            await db.SaveChangesAsync();
        }
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

        var trm = await db.Terms
            .Include(x => x.WeekAssessments)
            .FirstOrDefaultAsync(x => x.TermId == term.TermId);

        if (trm != null)
        {
            trm.TermName = term.TermName;
            trm.TermDesc = term.TermDesc;
            trm.WeekAssessments = term.WeekAssessments;

            await db.SaveChangesAsync();
        }
    }
}