using Arguments.Argument.Registration.CustomerAddress;
using Domain.DTO.Base;

namespace Domain.DTO.Entity.CustomerAddress
{
    public class CustomerAddressValidateDTO : BaseValidateDTO
    {
        public InputCreateCustomerAddress InputCreateCustomerAddress { get; set; }
        public InputUpdateCustomerAddress InputUpdateCustomerAddress { get; set; }
        public InputIdentityUpdateCustomerAddress InputIdentityUpdateCustomerAddress { get; set; }
    }
}