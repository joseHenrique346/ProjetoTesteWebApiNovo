using Arguments.Argument.Registration.CustomerAddress;
using Domain.DTO.Entity;
using Domain.Interface.Repository;
using Domain.Service.Base;

namespace Domain.Service.Registration
{
    public class CustomerAddressService : BaseService<CustomerAddressDTO, ICustomerAddressRepository, InputIdentityViewCustomerAddress, InputCreateCustomerAddress, InputUpdateCustomerAddress, InputIdentityUpdateCustomerAddress, InputIdentityDeleteCustomer, OutputCustomerAddres>
    {
        public CustomerAddressService(ICustomerAddressRepository repository) : base(repository) { }
    }
}
