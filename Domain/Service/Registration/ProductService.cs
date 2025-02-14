using Arguments.Argument.Registration.Product;
using Domain.DTO.Entity;
using Domain.Interface.Repository;
using Domain.Service.Base;

namespace Domain.Service.Registration
{
    public class ProductService : BaseService<ProductDTO, IProductRepository, InputIdentityViewProduct, InputCreateProduct, InputUpdateProduct, InputIdentityUpdateProduct, InputIdentityDeleteCustomer, OutputProduct>
    {
        public ProductService(IProductRepository repository) : base(repository) { }
    }
}
