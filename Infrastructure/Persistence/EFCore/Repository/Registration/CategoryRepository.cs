using AutoMapper;
using Domain.DTO.Entity;
using Domain.Interface.Repository;
using Infrastructure.Persistence.EFCore.Context;
using Infrastructure.Persistence.EFCore.Entity.Registration;
using Infrastructure.Persistence.EFCore.Repository.Base;

namespace Infrastructure.Persistence.EFCore.Repository.Registration
{
    public class CategoryRepository(AppDbContext context, IMapper mapper) : BaseRepository<Category, CategoryDTO>(context, mapper), ICategoryRepository { }
}