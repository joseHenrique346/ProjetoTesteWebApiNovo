using Domain.DTO.Entity;
using Domain.Interface.Repository;
using Infrastructure.Persistence.EFCore.Context;
using Infrastructure.Persistence.EFCore.Entity.Registration;
using Infrastructure.Persistence.EFCore.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EFCore.Repository.Registration
{
    public class BrandRepository : BaseRepository<Brand, BrandDTO>, IBrandRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<Brand> _dbSet;

        public BrandRepository(AppDbContext context, IMapper mapper, DbSet<Brand> dbSet) : base(context, mapper)
        {
            _dbSet = dbSet;
        }

        public async Task<List<BrandDTO>> GetListByListCode(List<string> code)
        {
            var allBrands = await GetAll();
            FromDtoToEntity(allBrands);

            var listEntity = (from i in allBrands
                              from j in code
                              where i.Code == j
                              select i).ToList();

            return listEntity;
        }
    }
}