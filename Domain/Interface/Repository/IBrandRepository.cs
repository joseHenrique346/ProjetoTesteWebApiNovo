using Arguments.Argument.Registration.Brand;
using Domain.DTO.Entity;
using Domain.Interface.Base;

namespace Domain.Interface.Repository
{
    public interface IBrandRepository : IBaseRepository<BrandDTO, InputIdentityViewBrand>
    {
        Task<List<BrandDTO>> GetListByListCode(List<string> listCode);
    }
}