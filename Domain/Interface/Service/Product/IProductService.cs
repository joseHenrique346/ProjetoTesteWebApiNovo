using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Registration.Product;

namespace Domain.Interface.Service.Product
{
    public interface IProductService
    {
        Task<BaseResult<List<OutputProduct>>> CreateMultiple(List<InputCreateProduct> listInputCreateProduct);
        Task<BaseResult<List<OutputProduct>>> UpdateMultiple(List<InputIdentityUpdateProduct> listInputIdentityUpdateProduct);
        Task<BaseResult<bool>> DeleteMultiple(List<InputIdentityDeleteProduct> listInputIdentityDeleteProduct);
    }
}