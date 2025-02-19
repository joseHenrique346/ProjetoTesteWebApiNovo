using Arguments.Argument.Registration.Customer;
using Domain.DTO.Base;

namespace Domain.DTO.Entity.Customer
{
    public class CustomerValidateDTO : BaseValidateDTO
    {
        public InputCreateCustomer InputCreateCustomer { get; set; }
        public InputUpdateCustomer InputUpdateCustomer { get; set; }
        public InputIdentityUpdateCustomer InputIdentityUpdateCustomer { get; set; }
        public InputIdentityDeleteCustomer InputIdentityDeleteCustomer { get; set; }
    }
}