using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Registration.Brand;

namespace Domain.Interface.Service.Brand
{
    public interface IBrandService
    {
        Task<BaseResult<List<OutputBrand>>> CreateMultiple(List<InputCreateBrand> listInputCreateBrand);
        Task<BaseResult<List<OutputBrand>>> UpdateMultiple(List<InputIdentityUpdateBrand> listInputIdentityUpdateBrand);
    }
}
