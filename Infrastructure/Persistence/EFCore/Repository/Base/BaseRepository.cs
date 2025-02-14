using Arguments.Argument.Base;
using Arguments.Argument.Conversor;
using Domain.DTO.Base;
using Domain.Interface.Base;
using Infrastructure.Mapper;
using Infrastructure.Persistence.EFCore.Context;
using Infrastructure.Persistence.EFCore.Entity.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EFCore.Repository.Base
{
    public abstract class BaseRepository<TEntity, TDTO, TInputIdentityView> : IBaseRepository<TDTO, TInputIdentityView>
        where TEntity : BaseEntity, new()
        where TInputIdentityView : BaseInputIdentityView<TInputIdentityView>
        where TDTO : BaseDTO, new()
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

        public async Task<List<TDTO>> GetAll()
        {
            var listEntity = await _dbSet.ToListAsync();
            return listEntity.GenericConvertList<TDTO, TEntity>();
        }
        public async Task<List<TDTO>> GetListByListId(List<TInputIdentityView> listId)
        {
            var getList = (from i in listId
                           select _dbSet.Find(i)).ToList();
            return getList.GenericConvertList<TDTO, TEntity>();
        }

        public async Task<TDTO?> GetById(TInputIdentityView? id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity == null ? default : entity.GenericConvert<TDTO, TEntity>();
        }

        #endregion

        #region Create

        public async Task<List<TDTO>> Create(List<TDTO> listDTO)
        {
            List<TEntity> listEntity = Conversor.GenericConvertList<TEntity, TDTO>(listDTO);
            _dbSet.AddRange(listEntity);
            await _context.SaveChangesAsync();
            return listEntity.GenericConvertList<TDTO, TEntity>();
        }

        #endregion

        #region Update

        public async Task<List<TDTO>> Update(List<TDTO> listDto)
        {
            List<TEntity> listEntity = Conversor.GenericConvertList<TEntity, TDTO>(listDto);
            _dbSet.UpdateRange(listEntity);
            await _context.SaveChangesAsync();
            return listEntity.GenericConvertList<TDTO, TEntity>();
        }

        #endregion

        #region Delete

        public async Task<bool> Delete(List<TDTO> listDto)
        {
            List<TEntity> listEntity = Conversor.GenericConvertList<TEntity, TDTO>(listDto);
            _dbSet.RemoveRange(listEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        #endregion
    }
}