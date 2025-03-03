using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Registration.Category;
using Domain.DTO.Entity.Category;
using Domain.Interface.Service.Base;

namespace Domain.Interface.Service.Category
{
    public interface ICategoryService : IBaseService<CategoryDTO, OutputCategory, InputIdentityViewCategory, InputCreateCategory, InputIdentityUpdateCategory, InputIdentityDeleteCategory>
    {
        Task<BaseResult<List<OutputCategory>>> CreateMultiple(List<InputCreateCategory> listInputCreateCategory);
        Task<BaseResult<List<OutputCategory>>> UpdateMultiple(List<InputIdentityUpdateCategory> listInputIdentityUpdateCategory);
        Task<BaseResult<bool>> DeleteMultiple(List<InputIdentityDeleteCategory> listInputIdentityDeleteCategory);
    }
}
