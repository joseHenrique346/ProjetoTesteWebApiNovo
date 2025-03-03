using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Registration.Brand;
using Domain.DTO.Entity.Brand;
using Domain.Interface.Service.Base;

namespace Domain.Interface.Service.Brand
{
    public interface IBrandService : IBaseService<BrandDTO, OutputBrand, InputIdentityViewBrand, InputCreateBrand, InputIdentityUpdateBrand, InputIdentityDeleteBrand>
    {
        Task<BaseResult<List<OutputBrand>>> CreateMultiple(List<InputCreateBrand> listInputCreateBrand);
        Task<BaseResult<List<OutputBrand>>> UpdateMultiple(List<InputIdentityUpdateBrand> listInputIdentityUpdateBrand);
    }
}
