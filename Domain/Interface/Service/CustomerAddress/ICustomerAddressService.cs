using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Registration.CustomerAddress;

namespace Domain.Interface.Service.CustomerAddress
{
    public interface ICustomerAddressService
    {
        Task<BaseResult<List<OutputCustomerAddress>>> CreateMultiple(List<InputCreateCustomerAddress> listInputCreateCustomerAddress);
        Task<BaseResult<List<OutputCustomerAddress>>> UpdateMultiple(List<InputIdentityUpdateCustomerAddress> listInputIdentityUpdateCustomerAddress);
    }
}
