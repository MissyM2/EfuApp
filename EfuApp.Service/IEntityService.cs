using EfuApp.CoreBusiness.Base;

namespace EfuApp.Service
{
    public interface IEntityService<TEntity> where TEntity: EntityBase
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> GetByKeyAsync(params object[] keys);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetByParamAsync(/*DataSourceParameter dataSourceParam*/);

        Task<int> SaveAsync(TEntity entityToSave);

        bool Exists(int id);

        // works with those entities that have alternative identity keys:  such as a table with a string data type or a composite key
        bool Exists(params object[] keys);
    }
}
