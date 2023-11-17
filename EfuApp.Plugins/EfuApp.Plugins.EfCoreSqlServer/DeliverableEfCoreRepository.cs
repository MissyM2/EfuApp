using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EfuApp.Plugins.EfCoreSqlServer;

public class DeliverableEfCoreRepository : IDeliverableRepository
{
    private readonly IDbContextFactory<EfuAppContext> contextFactory;

    public DeliverableEfCoreRepository(IDbContextFactory<EfuAppContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Deliverable>> GetDeliverablesByNameAsync(string name)
    {
        using var db = this.contextFactory.CreateDbContext();

        return await db.Deliverables
            .Where(x => x.DeliverableName.ToLower().IndexOf(name.ToLower()) >= 0)
            .Include(deliverable => deliverable.Course)
            .ToListAsync();
    }

    public async Task AddDeliverableAsync(Deliverable deliverable)
    {
        using var db = this.contextFactory.CreateDbContext();

        db.Deliverables.Add(deliverable);
        await db.SaveChangesAsync();
    }

    public async Task<Deliverable> GetDeliverableByIdAsync(int deliverableId)
    {
        using var db = this.contextFactory.CreateDbContext();

        var del = await db.Deliverables.FindAsync(deliverableId);
        if (del != null) return del;

        return new Deliverable();
    }

    public async Task<IEnumerable<Deliverable>> GetDeliverablesByCourseIdAsync(int courseId)
    {
        using var db = this.contextFactory.CreateDbContext();

        return await db.Deliverables
            .Where(x => x.CourseId == courseId)
            .ToListAsync();
    }

    public async Task UpdateDeliverableAsync(Deliverable deliverable)
    {
        using var db = this.contextFactory.CreateDbContext();

        var del = await db.Deliverables.FindAsync(deliverable.Id);
        if (del != null)
        {
            del.DeliverableName = deliverable.DeliverableName;
            del.DeliverableDesc = deliverable.DeliverableDesc;

            await db.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Deliverable>> GetDeliverablesByDateAsync(string name)
    {
        using var db = this.contextFactory.CreateDbContext();

        return await db.Deliverables.Where(
            x => x.DeliverableName.ToLower().IndexOf(name.ToLower()) >= 0).ToListAsync();

    }

    public async Task<IEnumerable<Deliverable>> GetDeliverablesByCourseNameAsync(string crsName)
    {
        using var db = this.contextFactory.CreateDbContext();

        var deliverablesList = await db.Deliverables
            .Include(deliverable => deliverable.Course)
            .ToListAsync();
        return deliverablesList.Where(x => x.Course.CourseName == crsName);

    }
}