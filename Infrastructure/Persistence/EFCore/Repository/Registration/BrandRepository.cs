using Arguments.Argument.Registration.Brand;
using Arguments.Conversor;
using Domain.DTO.Entity.Brand;
using Domain.Interface.Repository;
using Infrastructure.Persistence.EFCore.Context;
using Infrastructure.Persistence.EFCore.Entity.Registration;
using Infrastructure.Persistence.EFCore.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EFCore.Repository.Registration
{
    public class BrandRepository : BaseRepository<Brand, BrandDTO, InputIdentityViewBrand>, IBrandRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Brand> _dbSet;

        public BrandRepository(AppDbContext context, DbSet<Brand> dbSet) : base(context)
        {
            _dbSet = dbSet;
        }

        public async Task<List<BrandDTO>> GetListByListCode(List<string> code)
        {
            var allBrands = await GetAll();
            allBrands.GenericConvertList<Brand, BrandDTO>();

            var listEntity = (from i in allBrands
                              from j in code
                              where i.Code == j
                              select i).ToList();

            return listEntity;
        }
    }
}