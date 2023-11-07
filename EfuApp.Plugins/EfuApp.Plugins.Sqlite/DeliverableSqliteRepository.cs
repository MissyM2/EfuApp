using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using SQLite;

namespace EfuApp.Plugins.Sqlite;

public class DeliverableSqliteRepository : IDeliverableRepository
{
    private SQLiteAsyncConnection _dbConnection;

    private async void SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EfuAppSqliteDb.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath, Constants.Flags);
                await _dbConnection.CreateTableAsync<Deliverable>();

                try
                {
                    await _dbConnection.CreateTableAsync<Deliverable>();

                    var rowCount = await _dbConnection.Table<Deliverable>().CountAsync();
                    if (rowCount == 0)
                    {
                        AddDeliverableSeedData();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("CreateDatabase " + ex.Message.ToString());
                }
            }
        }


    void AddDeliverableSeedData()
    {
        var item1 = new Deliverable { DeliverableName = "English Essay", DeliverableDesc = "5 paragraphs", AssignmentDate = new DateTime(2023, 9, 15), DueDate = new DateTime(2023, 10, 15)};
        var item2 = new Deliverable { DeliverableName = "Sociology Term Paper", DeliverableDesc = "5 paragraphs", AssignmentDate = new DateTime(2023, 9, 1), DueDate = new DateTime(2023, 9, 29)  };
        var item3 = new Deliverable { DeliverableName = "Psychology Study", DeliverableDesc = "5 pages; topic of your choice", AssignmentDate = new DateTime(2023, 9, 10), DueDate = new DateTime(2023, 9, 20)};
        var item4 = new Deliverable { DeliverableName = "Math Homework", DeliverableDesc = "2 worksheets", AssignmentDate = new DateTime(2023, 9, 20), DueDate = new DateTime(2023, 9, 21) };

        _dbConnection.InsertAsync(item1);
        _dbConnection.InsertAsync(item2);
        _dbConnection.InsertAsync(item3);
        _dbConnection.InsertAsync(item4);

    }

     public async Task<IEnumerable<Deliverable>> GetDeliverablesByNameAsync(string name)
    {
        SetUpDb();
        
        if (string.IsNullOrWhiteSpace(name))
                return await _dbConnection.Table<Deliverable>().ToListAsync();

        return await _dbConnection.Table<Deliverable>().Where(x => x.DeliverableName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
    }

    public async Task AddDeliverableAsync(Deliverable deliverable)
    {
        var existingItems = await _dbConnection.Table<Deliverable>().Where(x => x.DeliverableName.Contains(deliverable.DeliverableName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        if (existingItems.Count > 0 ) return;

        await _dbConnection.InsertAsync(deliverable);
    }

     public async Task<Deliverable> GetDeliverableByIdAsync(int deliverableId)
    {

        return await _dbConnection.Table<Deliverable>().Where(x => x.DeliverableId == deliverableId).FirstOrDefaultAsync();
    }

     public async Task UpdateDeliverableAsync(Deliverable deliverable)
        {

            // we are not allowing two different deliverables to have the same name, so we have to check to make sure

            var existingItems = await _dbConnection.Table<Deliverable>().Where(x => x.DeliverableId != deliverable.DeliverableId && x.DeliverableName.Contains(deliverable.DeliverableName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            if (existingItems.Count > 0 ) return;

             var del = await _dbConnection.Table<Deliverable>().FirstOrDefaultAsync(x => x.DeliverableId == deliverable.DeliverableId);
            if (del != null)
            {
                del.DeliverableName = deliverable.DeliverableName;
                del.DeliverableDesc = deliverable.DeliverableDesc;
                del.AssignmentDate = deliverable.AssignmentDate;
                del.DueDate = deliverable.DueDate;
            }

            await _dbConnection.UpdateAsync(del);
        }

    public async Task<IEnumerable<Deliverable>> GetDeliverablesByDateAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
                return await _dbConnection.Table<Deliverable>().ToListAsync();

        return await _dbConnection.Table<Deliverable>().Where(x => x.DeliverableName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
    }

    public async Task<IEnumerable<Deliverable>> GetDeliverablesByCourseNameAsync(string crsName)
    {
        var deliverablesList = await _dbConnection.Table<Deliverable>()
            //.Include(deliverable => deliverable.Course)
            .ToListAsync();
        return deliverablesList.Where(x => x.Course.CourseName == crsName);

    }
}
