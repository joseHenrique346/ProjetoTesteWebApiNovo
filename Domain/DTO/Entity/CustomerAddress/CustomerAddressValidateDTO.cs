using Arguments.Argument.Registration.CustomerAddress;
using Domain.DTO.Base;
using Domain.DTO.Entity.Customer;

namespace Domain.DTO.Entity.CustomerAddress
{
    public class CustomerAddressValidateDTO : BaseValidateDTO_1<InputCreateCustomerAddress, InputUpdateCustomerAddress, InputIdentityDeleteCustomerAddress>
    {
        public InputCreateCustomerAddress InputCreate { get; set; }
        public CustomerDTO? RelatedCustomerDTO { get; set; }

        public InputUpdateCustomerAddress InputUpdate { get; set; }
        public CustomerAddressDTO? OriginalCustomerAddress { get; set; }

        public InputIdentityUpdateCustomerAddress InputIdentityUpdateCustomerAddress { get; set; }
        public InputIdentityDeleteCustomerAddress InputIdentityDeleteCustomerAddress { get; set; }

        public CustomerAddressValidateDTO ValidateCreate(InputCreateCustomerAddress inputCreate, CustomerDTO? relatedCustomerDTO)
        {
            InputCreate = inputCreate;
            RelatedCustomerDTO = relatedCustomerDTO;
            return this;
        }

        public CustomerAddressValidateDTO ValidateUpdate(InputUpdateCustomerAddress inputUpdate, CustomerAddressDTO? originalCustomerAddress)
        {
            InputUpdate = inputUpdate;
            OriginalCustomerAddress = originalCustomerAddress;
            return this;
        }

        public CustomerAddressValidateDTO ValidateDelete(InputIdentityDeleteCustomerAddress inputIdentityDeleteCustomerAddress, CustomerAddressDTO? originalCustomerAddress)
        {
            InputIdentityDeleteCustomerAddress = inputIdentityDeleteCustomerAddress;
            OriginalCustomerAddress = originalCustomerAddress;
            return this;
        }
    }
}