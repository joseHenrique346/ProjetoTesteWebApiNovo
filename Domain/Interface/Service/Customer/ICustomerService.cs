using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Registration.Customer;

namespace Domain.Interface.Service.Customer
{
    public interface ICustomerService
    {
        Task<BaseResult<List<OutputCustomer>>> CreateMultiple(List<InputCreateCustomer> listInputCreateCustomer);
        Task<BaseResult<List<OutputCustomer>>> UpdateMultiple(List<InputIdentityUpdateCustomer> listInputIdentityUpdateCustomer);
        Task<BaseResult<bool>> DeleteMultiple(List<InputIdentityDeleteCustomer> listInputIdentityDeleteCustomer);
    }
}
