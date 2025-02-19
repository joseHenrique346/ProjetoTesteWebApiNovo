using Arguments.Argument.Registration.Product;
using Domain.DTO.Entity.Product;
using Domain.Interface.Repository;
using Infrastructure.Persistence.EFCore.Context;
using Infrastructure.Persistence.EFCore.Entity.Registration;
using Infrastructure.Persistence.EFCore.Repository.Base;

namespace Infrastructure.Persistence.EFCore.Repository.Registration
{
    public class ProductRepository(AppDbContext context) : BaseRepository<Product, ProductDTO, InputIdentityViewProduct>(context), IProductRepository { }
}