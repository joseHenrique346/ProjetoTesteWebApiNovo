using Arguments.Argument.Registration.CustomerAddress;
using Domain.DTO.Entity;
using Domain.Interface.Repository;

namespace Domain.Service.Registration.CustomerAddress
{
    public class CustomerAddressService : BaseService<CustomerAddressDTO, ICustomerAddressRepository, InputIdentityViewCustomerAddress, InputCreateCustomerAddress, InputUpdateCustomerAddress, InputIdentityUpdateCustomerAddress, InputIdentityDeleteCustomer, OutputCustomerAddres>
    {
        public CustomerAddressService(ICustomerAddressRepository repository) : base(repository) { }
    }
}
