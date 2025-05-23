namespace Nettium_Test.Application.Interfaces.Repositories.Shares
{
    public interface IGenericRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(object id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> Deletesync(object id);
    }
}
