using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Registration.Category;

namespace Domain.Interface.Service.Category
{
    public interface ICategoryService
    {
        Task<BaseResult<List<OutputCategory>>> CreateMultiple(List<InputCreateCategory> listInputCreateCategory);
        Task<BaseResult<List<OutputCategory>>> UpdateMultiple(List<InputIdentityUpdateCategory> listInputIdentityUpdateCategory);
        Task<BaseResult<bool>> DeleteMultiple(List<InputIdentityDeleteCategory> listInputIdentityDeleteCategory);
    }
}
