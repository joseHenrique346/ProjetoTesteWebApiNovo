using Arguments.Argument.Registration.Category;
using Domain.DTO.Entity;
using Domain.Interface.Base;

namespace Domain.Interface.Repository
{
    public interface ICategoryRepository : IBaseRepository<CategoryDTO, InputIdentityViewCategory> { }
}
