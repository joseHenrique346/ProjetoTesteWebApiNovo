using Arguments.Argument.Registration.Brand;
using Domain.DTO.Entity.Brand;
using Domain.Interface.Base;

namespace Domain.Interface.Repository
{
    public interface IBrandRepository : IBaseRepository<BrandDTO, InputIdentityViewBrand>
    {
        Task<List<BrandDTO>> GetListByListCode(List<string> listCode);
    }
}