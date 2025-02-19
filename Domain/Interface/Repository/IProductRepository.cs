using Arguments.Argument.Registration.Product;
using Domain.DTO.Entity.Product;
using Domain.Interface.Base;

namespace Domain.Interface.Repository
{
    public interface IProductRepository : IBaseRepository<ProductDTO, InputIdentityViewProduct> { }
}
