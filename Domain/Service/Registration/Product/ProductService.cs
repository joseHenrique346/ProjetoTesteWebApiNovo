using Arguments.Argument.Registration.Product;
using Domain.DTO.Entity;
using Domain.Interface.Repository;

namespace Domain.Service.Registration.Product
{
    public class ProductService : BaseService<ProductDTO, IProductRepository, InputIdentityViewProduct, InputCreateProduct, InputUpdateProduct, InputIdentityUpdateProduct, InputIdentityDeleteCustomer, OutputProduct>
    {
        public ProductService(IProductRepository repository) : base(repository) { }
    }
}
