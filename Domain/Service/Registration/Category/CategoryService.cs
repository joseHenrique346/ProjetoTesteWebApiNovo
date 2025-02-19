using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Registration.Category;
using Domain.DTO.Entity.Category;
using Domain.Interface.Repository;
using Domain.Service.Base;

namespace Domain.Service.Registration.Category
{
    public class CategoryService : BaseService<CategoryDTO, ICategoryRepository, InputIdentityViewCategory, InputCreateCategory, InputUpdateCategory, InputIdentityUpdateCategory, InputIdentityDeleteCategory, CategoryValidateDTO, OutputCategory>
    {
        public CategoryService(ICategoryRepository repository) : base(repository) { }

        public override List<OutputCategory> CreateMultiple(List<InputCreateCategory> listInputCreateCategory)
        {
            throw new NotImplementedException();
        }

        public override async Task<BaseResult<List<OutputCategory>>> UpdateMultiple(List<InputIdentityUpdateCategory> listInputIdentityUpdateCategory)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteMultiple(List<InputIdentityDeleteCategory> listInputIdentityDeleteCategory)
        {
            throw new NotImplementedException();
        }
    }
}