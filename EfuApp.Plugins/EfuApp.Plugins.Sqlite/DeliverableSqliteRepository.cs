using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using SQLite;

namespace EfuApp.Plugins.Sqlite;

public class DeliverableSqliteRepository : IDeliverableRepository
{
    private SQLiteAsyncConnection database;

    public DeliverableSqliteRepository()
    {
        this.database = new SQLiteAsyncConnection(Constants.DatabasePath);
       
        this.database.CreateTableAsync<Deliverable>();

        // _deliverables = new List<Deliverable>()
        // {
        //     new Deliverable { DeliverableId = 1, DeliverableName = "English Essay", DeliverableDesc = "5 paragraphs", AssignmentDate = new DateTime(2023, 9, 15), DueDate = new DateTime(2023, 10, 15)},
        //     new Deliverable { DeliverableId = 2, DeliverableName = "Sociology Term Paper", DeliverableDesc = "5 paragraphs", AssignmentDate = new DateTime(2023, 9, 1), DueDate = new DateTime(2023, 9, 29) },
        //     new Deliverable { DeliverableId = 3, DeliverableName = "Psychology Study", DeliverableDesc = "5 pages; topic of your choice", AssignmentDate = new DateTime(2023, 9, 10), DueDate = new DateTime(2023, 9, 20)},
        //     new Deliverable { DeliverableId = 4, DeliverableName = "Math Homework", DeliverableDesc = "2 worksheets", AssignmentDate = new DateTime(2023, 9, 20), DueDate = new DateTime(2023, 9, 21) }
        // };
    }

     public async Task<IEnumerable<Deliverable>> GetDeliverablesByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
                return await this.database.Table<Deliverable>().ToListAsync();

        return await this.database.Table<Deliverable>().Where(x => x.DeliverableName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
    }

    public async Task AddDeliverableAsync(Deliverable deliverable)
    {
        var existingItems = await this.database.Table<Deliverable>().Where(x => x.DeliverableName.Contains(deliverable.DeliverableName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        if (existingItems.Count > 0 ) return;

        await this.database.InsertAsync(deliverable);
    }

     public async Task<Deliverable> GetDeliverableByIdAsync(int deliverableId)
    {

        return await this.database.Table<Deliverable>().Where(x => x.DeliverableId == deliverableId).FirstOrDefaultAsync();
    }

     public async Task UpdateDeliverableAsync(Deliverable deliverable)
        {

            // we are not allowing two different deliverables to have the same name, so we have to check to make sure

            var existingItems = await this.database.Table<Deliverable>().Where(x => x.DeliverableId != deliverable.DeliverableId && x.DeliverableName.Contains(deliverable.DeliverableName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            if (existingItems.Count > 0 ) return;

             var del = await this.database.Table<Deliverable>().FirstOrDefaultAsync(x => x.DeliverableId == deliverable.DeliverableId);
            if (del != null)
            {
                del.DeliverableName = deliverable.DeliverableName;
                del.DeliverableDesc = deliverable.DeliverableDesc;
                del.AssignmentDate = deliverable.AssignmentDate;
                del.DueDate = deliverable.DueDate;
            }

            await this.database.UpdateAsync(del);
        }

    public async Task<IEnumerable<Deliverable>> GetDeliverablesByDateAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
                return await this.database.Table<Deliverable>().ToListAsync();

        return await this.database.Table<Deliverable>().Where(x => x.DeliverableName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
    }
}
