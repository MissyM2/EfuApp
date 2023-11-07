using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EfuApp.Plugins.EfCoreSqlServer;

public class DeliverableEfCoreRepository : IDeliverableRepository
{
    private readonly EfuAppContext context;

    public DeliverableEfCoreRepository(EfuAppContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Deliverable>> GetDeliverablesByNameAsync(string name)
    {
        return await context.Deliverables
            .Where(x => x.DeliverableName.ToLower().IndexOf(name.ToLower()) >= 0)
            .Include(deliverable => deliverable.Course)
            .ToListAsync();
    }

    public async Task AddDeliverableAsync(Deliverable deliverable)
    {
        context.Deliverables.Add(deliverable);
        await context.SaveChangesAsync();
    }

    public async Task<Deliverable> GetDeliverableByIdAsync(int deliverableId)
    {
        var del = await context.Deliverables.FindAsync(deliverableId);
        if (del != null) return del;

        return new Deliverable();
    }

    public async Task UpdateDeliverableAsync(Deliverable deliverable)
    {
        var del = await context.Deliverables.FindAsync(deliverable.DeliverableId);
        if (del != null)
        {
            del.DeliverableName = deliverable.DeliverableName;
            del.DeliverableDesc = deliverable.DeliverableDesc;

            await context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Deliverable>> GetDeliverablesByDateAsync(string name)
    {
        return await context.Deliverables.Where(
            x => x.DeliverableName.ToLower().IndexOf(name.ToLower()) >= 0).ToListAsync();

    }

    public async Task<IEnumerable<Deliverable>> GetDeliverablesByCourseNameAsync(string crsName)
    {
        var deliverablesList = await context.Deliverables
            .Include(deliverable => deliverable.Course)
            .ToListAsync();
        return deliverablesList.Where(x => x.Course.CourseName == crsName);

    }
}