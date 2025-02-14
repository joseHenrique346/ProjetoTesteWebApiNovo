using Arguments.Argument.Registration.Category;
using Domain.DTO.Entity;
using Domain.Interface.Repository;
using Domain.Service.Base;

namespace Domain.Service.Registration
{
    public class CategoryService : BaseService<CategoryDTO, ICategoryRepository, InputIdentityViewCategory, InputCreateCategory, InputUpdateCategory, InputIdentityUpdateCategory, InputIdentityDeleteCategory, OutputCategory>
    {
        public CategoryService(ICategoryRepository repository) : base(repository) { }
    }
}
