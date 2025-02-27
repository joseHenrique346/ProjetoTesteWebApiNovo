using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Registration.Product;
using Domain.DTO.Entity.Customer;
using Domain.DTO.Entity.Product;
using Domain.Interface.Repository;
using Domain.Service.Base;

namespace Domain.Service.Registration.Product
{
    public class ProductService : BaseService<ProductDTO, IProductRepository, InputIdentityViewProduct, InputCreateProduct, InputUpdateProduct, InputIdentityUpdateProduct, InputIdentityDeleteProduct, CustomerValidateDTO, OutputProduct>
    {
        public ProductService(IProductRepository repository) : base(repository) { }

        public override Task<BaseResult<List<OutputProduct>>> CreateMultiple(List<InputCreateProduct> listInputCreateProduct)
        {
            throw new NotImplementedException();
        }

        public override Task<BaseResult<List<OutputProduct>>> UpdateMultiple(List<InputIdentityUpdateProduct> listInputIdentityUpdateProduct)
        {
            var listOriginalProduct = 
        }

        public override Task<BaseResult<bool>> DeleteMultiple(List<InputIdentityDeleteProduct> listInputIdentityDeleteProduct)
        {
            throw new NotImplementedException();
        }
    }
}