using Arguments.Argument.Registration.Brand;
using Domain.DTO.Entity.Brand;
using Domain.Interface.Service.Base;

namespace Domain.Interface.Service.Brand
{
    public interface IBrandService : IBaseService<BrandDTO, OutputBrand, InputIdentityViewBrand, InputCreateBrand, InputIdentityUpdateBrand, InputIdentityDeleteBrand> { }
}
