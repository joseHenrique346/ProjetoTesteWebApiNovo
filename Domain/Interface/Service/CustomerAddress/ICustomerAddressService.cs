using Arguments.Argument.Registration.CustomerAddress;
using Domain.DTO.Entity.CustomerAddress;
using Domain.Interface.Service.Base;

namespace Domain.Interface.Service.CustomerAddress
{
    public interface ICustomerAddressService : IBaseService<CustomerAddressDTO, OutputCustomerAddress, InputIdentityViewCustomerAddress, InputCreateCustomerAddress, InputIdentityUpdateCustomerAddress, InputIdentityDeleteCustomerAddress>
    {
        Task<BaseResult<List<OutputCustomerAddress>>> CreateMultiple(List<InputCreateCustomerAddress> listInputCreateCustomerAddress);
        Task<BaseResult<List<OutputCustomerAddress>>> UpdateMultiple(List<InputIdentityUpdateCustomerAddress> listInputIdentityUpdateCustomerAddress);
    }
}
