namespace Domain.Interface.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetListByListId(List<long> id);
        Task<TEntity?> GetById(long? id);
        Task<List<TEntity>> Create(List<TEntity> listEntity);
        Task<List<TEntity>> Update(List<TEntity> listEntity);
        Task<bool> Delete(List<TEntity> listEntity);
    }
}
