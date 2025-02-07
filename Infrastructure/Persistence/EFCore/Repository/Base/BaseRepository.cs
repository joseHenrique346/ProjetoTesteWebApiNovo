using Domain.Interface.Base;
using Infrastructure.Persistence.EFCore.Context;
using Infrastructure.Persistence.EFCore.Entity.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EFCore.Repository.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        #region Dependency Injection

        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        #endregion

        #region Get

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<List<TEntity>> GetListByListId(List<long> listId)
        {
            var getList = (from i in listId
                           select _dbSet.Find(i)).ToList();
            return getList;
        }

        public async Task<TEntity?> GetById(long? id)
        {
            return await _dbSet.FindAsync(id);
        }

        #endregion

        #region Create

        public async Task<List<TEntity>> Create(List<TEntity> listEntity)
        {
            _dbSet.AddRange(listEntity);
            await _context.SaveChangesAsync();
            return listEntity;
        }

        #endregion

        #region Update

        public async Task<List<TEntity>> Update(List<TEntity> listEntity)
        {
            _dbSet.UpdateRange(listEntity);
            await _context.SaveChangesAsync();
            return listEntity;
        }

        #endregion

        #region Delete

        public async Task<bool> Delete(List<TEntity> listEntity)
        {
            _dbSet.RemoveRange(listEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        #endregion
    }
}