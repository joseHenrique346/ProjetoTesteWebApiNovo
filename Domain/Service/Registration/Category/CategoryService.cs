using Arguments.Argument.Registration.Category;
using Domain.DTO.Entity;
using Domain.Interface.Repository;

namespace Domain.Service.Registration.Category
{
    public class CategoryService : BaseService<CategoryDTO, ICategoryRepository, InputIdentityViewCategory, InputCreateCategory, InputUpdateCategory, InputIdentityUpdateCategory, InputIdentityDeleteCategory, OutputCategory>
    {
        public CategoryService(ICategoryRepository repository) : base(repository) { }
    }
}
