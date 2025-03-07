using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Registration.Product;
using Domain.DTO.Entity.Product;
using Domain.Interface.Service.Base;

namespace Domain.Interface.Service.Product
{
    public interface IProductService : IBaseService<ProductDTO, OutputProduct, InputIdentityViewProduct, InputCreateProduct, InputIdentityUpdateProduct, InputIdentityDeleteProduct>
    {
        Task<BaseResult<List<OutputProduct>>> CreateMultiple(List<InputCreateProduct> listInputCreateProduct);
        Task<BaseResult<List<OutputProduct>>> UpdateMultiple(List<InputIdentityUpdateProduct> listInputIdentityUpdateProduct);
        Task<BaseResult<bool>> DeleteMultiple(List<InputIdentityDeleteProduct> listInputIdentityDeleteProduct);
    }
}