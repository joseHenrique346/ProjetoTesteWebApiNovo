using Arguments.Argument.Registration.Category;
using Domain.DTO.Entity.Category;
using Domain.Interface.Repository;
using Infrastructure.Persistence.EFCore.Context;
using Infrastructure.Persistence.EFCore.Entity.Registration;
using Infrastructure.Persistence.EFCore.Repository.Base;

namespace Infrastructure.Persistence.EFCore.Repository.Registration
{
    public class CategoryRepository(AppDbContext context) : BaseRepository<Category, CategoryDTO, InputIdentityViewCategory>(context), ICategoryRepository { }
}