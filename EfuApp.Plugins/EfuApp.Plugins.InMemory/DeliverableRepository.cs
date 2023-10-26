using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;

namespace EfuApp.Plugins.InMemory;

public class DeliverableRepository : IDeliverableRepository
{
    private List<Deliverable> _deliverables;

    public DeliverableRepository()
    {
        _deliverables = new List<Deliverable>()
        {
            new Deliverable { DeliverableId = 1, DeliverableName = "English Essay", DeliverableDesc = "5 paragraphs", AssignmentDate = new DateTime(2023, 9, 15), DueDate = new DateTime(2023, 10, 15)},
            new Deliverable { DeliverableId = 2, DeliverableName = "Sociology Term Paper", DeliverableDesc = "5 paragraphs", AssignmentDate = new DateTime(2023, 9, 1), DueDate = new DateTime(2023, 9, 29) },
            new Deliverable { DeliverableId = 3, DeliverableName = "Psychology Study", DeliverableDesc = "5 pages; topic of your choice", AssignmentDate = new DateTime(2023, 9, 10), DueDate = new DateTime(2023, 9, 20)},
            new Deliverable { DeliverableId = 4, DeliverableName = "Math Homework", DeliverableDesc = "2 worksheets", AssignmentDate = new DateTime(2023, 9, 20), DueDate = new DateTime(2023, 9, 21) }
        };
    }

    public async Task<IEnumerable<Deliverable>> GetDeliverablesByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_deliverables);

        return _deliverables.Where(x => x.DeliverableName.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public Task AddDeliverableAsync(Deliverable deliverable)
    {
        if (_deliverables.Any(x => x.DeliverableName.Equals(deliverable.DeliverableName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;
        
        var maxId = _deliverables.Max(x => x.DeliverableId);
        deliverable.DeliverableId = maxId + 1;

        _deliverables.Add(deliverable);

        return Task.CompletedTask;
    }

     public async Task<Deliverable> GetDeliverableByIdAsync(int deliverableId)
    {
        var c = _deliverables.First(x => x.DeliverableId == deliverableId);
        var newDeliverable = new Deliverable
        {
            DeliverableId = c.DeliverableId,
            DeliverableName = c.DeliverableName,
            DeliverableDesc = c.DeliverableDesc,
            AssignmentDate = c.AssignmentDate,
            DueDate = c.DueDate
        };

        return await Task.FromResult(newDeliverable);
    }

     public Task UpdateDeliverableAsync(Deliverable deliverable)
        {

            // we are not allowing two different deliverables to have the same name, so we have to check to make sure
            if (_deliverables.Any(x => x.DeliverableId != deliverable.DeliverableId &&
                x.DeliverableName.Equals(deliverable.DeliverableName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var del = _deliverables.FirstOrDefault(x => x.DeliverableId == deliverable.DeliverableId);
            if (del != null)
            {
                del.DeliverableName = deliverable.DeliverableName;
                del.DeliverableDesc = deliverable.DeliverableDesc;
                del.AssignmentDate = deliverable.AssignmentDate;
                del.DueDate = deliverable.DueDate;
            }

            return Task.CompletedTask;
        }

    public async Task<IEnumerable<Deliverable>> GetDeliverablesByDateAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_deliverables);

        return _deliverables.Where(x => x.DeliverableName.Contains(name, StringComparison.OrdinalIgnoreCase));
    }
}