using Arguments.Argument.Registration.CustomerAddress;
using Domain.DTO.Base;
using Domain.DTO.Entity.Customer;

namespace Domain.DTO.Entity.CustomerAddress
{
    public class CustomerAddressValidateDTO : BaseValidateDTO
    {
        public InputCreateCustomerAddress InputCreateCustomerAddress { get; set; }
        public CustomerDTO? RelatedCustomerDTO { get; set; }
        public InputUpdateCustomerAddress InputUpdateCustomerAddress { get; set; }
        public CustomerAddressDTO? OriginalCustomerAddress { get; set; }
        public InputIdentityUpdateCustomerAddress InputIdentityUpdateCustomerAddress { get; set; }

        public CustomerAddressValidateDTO ValidateCreate(InputCreateCustomerAddress inputCreateCustomerAddress, CustomerDTO? relatedCustomerDTO)
        {
            InputCreateCustomerAddress = inputCreateCustomerAddress;
            RelatedCustomerDTO = relatedCustomerDTO;
            return this;
        }

        public CustomerAddressValidateDTO ValidateUpdate(InputUpdateCustomerAddress inputUpdateCustomerAddress, CustomerAddressDTO? originalCustomerAddress)
        {
            InputUpdateCustomerAddress = inputUpdateCustomerAddress;
            OriginalCustomerAddress = originalCustomerAddress;
            return this;
        }

        public CustomerAddressValidateDTO ValidateDelete()
        {
            throw new NotImplementedException();
        }
    }
}