using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EfuApp.Plugins.EfCoreSqlServer
{
    public class WeekAssessmentEFCoreRepository : IWeekAssessmentRepository
    {
        private readonly IDbContextFactory<EfuAppContext> contextFactory;

        public WeekAssessmentEFCoreRepository(IDbContextFactory<EfuAppContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task AddWeekAssessmentAsync(WeekAssessment weekAssessment)
        {
            using var db = this.contextFactory.CreateDbContext();

            db.WeekAssessments.Add(weekAssessment);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<WeekAssessment>> GetWeekAssessmentsByTermIdAsync(int trmId)
        {
            using var db = this.contextFactory.CreateDbContext();

            return await db.WeekAssessments
                .Where(x => x.TermId == trmId)
                .ToListAsync();
        }

        public async Task UpdateWeekAssessmentAsync(WeekAssessment weekAssessment)
        {
            using var db = this.contextFactory.CreateDbContext();

            var wa = await db.WeekAssessments.FindAsync(weekAssessment.WeekAssessmentId);
            if (wa != null)
            {
                wa.WeekNumber = weekAssessment.WeekNumber;
                wa.LikedLeast = weekAssessment.LikedLeast;
                wa.LikedMost = weekAssessment.LikedMost;
                wa.MostDifficult = weekAssessment.MostDifficult;
                wa.LeastDifficult = weekAssessment.LeastDifficult;

                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<WeekAssessment>> GetWeekAssessmentsByTermNameAsync(string trmName)
        {
            using var db = this.contextFactory.CreateDbContext();

            var weekAssessmentsList = await db.WeekAssessments
                .Include(weekAssessment => weekAssessment.Term.TermName)
                .ToListAsync();

            return weekAssessmentsList.Where(x => x.Term.TermName == trmName);

        }
    }
}
