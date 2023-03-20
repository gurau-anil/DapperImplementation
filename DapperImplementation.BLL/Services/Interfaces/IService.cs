

namespace DapperImplementation.BLL.Services.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(int id);
    }
}
