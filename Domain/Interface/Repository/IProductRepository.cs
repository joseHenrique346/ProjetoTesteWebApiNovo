using Arguments.Argument.Registration.Product;
using Domain.DTO.Entity;
using Domain.Interface.Base;

namespace Domain.Interface.Repository
{
    public interface IProductRepository : IBaseRepository<ProductDTO, InputIdentityViewProduct> { }
}
