using Domain.DTO.Base;
using Domain.Interface.Base;
using Infrastructure.Persistence.EFCore.Context;
using Infrastructure.Persistence.EFCore.Entity.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EFCore.Repository.Base
{
    public abstract class BaseRepository<TEntity, TDTO> : IBaseRepository<TDTO>
        where TEntity : BaseEntity, new()
        where TDTO : BaseDTO, new()
    {
        #region Dependency Injection

        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private static IMapper _mapper;

        protected BaseRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            _mapper = mapper;
        }

        #endregion

        #region Get

        public async Task<List<TDTO>> GetAll()
        {
            var listEntity = await _dbSet.ToListAsync();
            return FromEntityToDto(listEntity);
        }
        public async Task<List<TDTO>> GetListByListId(List<long> listId)
        {
            var getList = (from i in listId
                           select _dbSet.Find(i)).ToList();
            return FromEntityToDto(getList);
        }

        public async Task<TDTO?> GetById(long? id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity == null ? default : _mapper.Map<TEntity, TDTO>(entity);
        }

        #endregion

        #region Create

        public async Task<List<TDTO>> Create(List<TDTO> listDTO)
        {
            List<TEntity> listEntity = FromDtoToEntity(listDTO);
            _dbSet.AddRange(listEntity);
            await _context.SaveChangesAsync();
            return FromEntityToDto(listEntity);
        }

        #endregion

        #region Update

        public async Task<List<TDTO>> Update(List<TDTO> listDto)
        {
            List<TEntity> listEntity = FromDtoToEntity(listDto);
            _dbSet.UpdateRange(listEntity);
            await _context.SaveChangesAsync();
            return FromEntityToDto(listEntity);
        }

        #endregion

        #region Delete

        public async Task<bool> Delete(List<TDTO> listDto)
        {
            List<TEntity> listEntity = FromDtoToEntity(listDto);
            _dbSet.RemoveRange(listEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        #endregion

        internal static List<TEntity> FromDtoToEntity(List<TDTO> listDto)
        {
            return _mapper.Map<List<TDTO>, List<TEntity>>(listDto);
        }

        internal static List<TDTO> FromEntityToDto(List<TEntity> listEntity)
        {
            return _mapper.Map<List<TEntity>, List<TDTO>>(listEntity);
        }
    }
}