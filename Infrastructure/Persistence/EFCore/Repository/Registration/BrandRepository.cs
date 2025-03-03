using Arguments.Argument.Registration.Brand;
using Arguments.Conversor;
using Domain.DTO.Entity.Brand;
using Domain.Interface.Repository;
using Infrastructure.Persistence.EFCore.Context;
using Infrastructure.Persistence.EFCore.Entity.Registration;
using Infrastructure.Persistence.EFCore.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Persistence.EFCore.Repository.Registration
{
    public class BrandRepository : BaseRepository<Brand, BrandDTO, InputIdentityViewBrand>, IBrandRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Brand> _dbSet;

        public BrandRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Brand>();
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