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

        public async Task AddWeekAssessmentsAsync(Term term, int wkCount, string userId)
        {
            using var db = this.contextFactory.CreateDbContext();

            for (int i = 1; i <= wkCount; i++)
            {
                db.WeekAssessments.Add(new WeekAssessment
                {
                    Id = term.Id,
                    Term = term,
                    WeekNumber = i,
                    LikedLeast = "",
                    LikedMost = "",
                    MostDifficult = "",
                    LeastDifficult = "",
                    //UserId = userId
                });

                await db.SaveChangesAsync();
            }
            await db.SaveChangesAsync();
        }

        public async Task<WeekAssessment> GetWeekAssessmentByIdAsync(int weekAssessmentId)
        {
            using var db = this.contextFactory.CreateDbContext();

            var wa = await db.WeekAssessments
                .FindAsync(weekAssessmentId);

            if (wa != null) return wa;

            return new WeekAssessment();

        }

        public async Task UpdateWeekAssessmentAsync(WeekAssessment weekAssessment)
        {
            using var db = this.contextFactory.CreateDbContext();

            var wa = await db.WeekAssessments.FindAsync(weekAssessment.Id);
            if (wa != null)
            {
                wa.WeekNumber = weekAssessment.WeekNumber;
                wa.LikedLeast = weekAssessment.LikedLeast;
                wa.LikedMost = weekAssessment.LikedMost;
                wa.MostDifficult = weekAssessment.MostDifficult;
                wa.LeastDifficult = weekAssessment.LeastDifficult;
                //wa.UserId = weekAssessment.UserId;

                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<WeekAssessment>> GetWeekAssessmentsByWeekNumberAsync()
        {
            using var db = this.contextFactory.CreateDbContext();

            return await db.WeekAssessments
                .Include(x => x.Term)
                .ToListAsync();


        }

        public async Task<IEnumerable<WeekAssessment>> GetWeekAssessmentsByTermAsync(int trmId)
        {
            using var db = this.contextFactory.CreateDbContext();

            var weekAssessmentList = await db.WeekAssessments
                .Include(x => x.Term)
                .ToListAsync();

            return weekAssessmentList.Where(x => x.Term.Id == trmId);
        }

        //public async Task<IEnumerable<WeekAssessment>> GetWeekAssessmentsByTermAsync(string trmName)
        //{
        //    using var db = this.contextFactory.CreateDbContext();

        //    var weekAssessmentList = await db.WeekAssessments
        //        .Include(x => x.Term)
        //        .ToListAsync();

        //    return weekAssessmentList.Where(x => x.Term.TermName == trmName);
        //}
    }
}
