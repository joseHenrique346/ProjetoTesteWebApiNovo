using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Registration.CustomerAddress;
using Arguments.Argument.Registration.CustomerAddress;
using Domain.DTO.Entity.CustomerAddress;
using Domain.Interface.Repository;
using Domain.Service.Base;

namespace Domain.Service.Registration.CustomerAddress
{
    public class CustomerAddressService : BaseService<CustomerAddressDTO, ICustomerAddressRepository, InputIdentityViewCustomerAddress, InputCreateCustomerAddress, InputUpdateCustomerAddress, InputIdentityUpdateCustomerAddress, InputIdentityDeleteCustomer, CustomerAddressValidateDTO, OutputCustomerAddress>
    {
        public CustomerAddressService(ICustomerAddressRepository repository) : base(repository) { }
        //public override List<OutputCustomerAddress> CreateMultiple(List<InputCreateCustomerAddress> listInputCreateCustomerAddress)
        //{
        //    throw new NotImplementedException();
        //}

        public override Task<BaseResult<List<OutputCustomerAddress>>> UpdateMultiple(List<InputIdentityUpdateCustomerAddress> listInputIdentityUpdateCustomerAddress)
        {
            throw new NotImplementedException();
        }
    }
}
