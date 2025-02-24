using Arguments.Argument.Enum;
using Arguments.Argument.Registration.Customer;
using Domain.DTO.Base;

namespace Domain.DTO.Entity.Customer
{
    public class CustomerValidateDTO : BaseValidateDTO
    {
        public InputCreateCustomer InputCreateCustomer { get; private set; }
        public string ExistingCode { get; set; }
        public InputCreateCustomer? RepeatedCode { get; set; }
        public EnumValidateType InvalidBirthDate { get; set; }

        public InputUpdateCustomer InputUpdateCustomer { get; private set; }
        public InputIdentityUpdateCustomer? RepeatedCodeUpdate { get; set; }

        public InputIdentityUpdateCustomer InputIdentityUpdateCustomer { get; private set; }
        public InputIdentityDeleteCustomer InputIdentityDeleteCustomer { get; private set; }
        public CustomerDTO OriginalCustomer { get; set; }

        public CustomerValidateDTO ValidateCreate(InputCreateCustomer inputCreateCustomer, string existingCode, InputCreateCustomer? repeatedCode,EnumValidateType birthDate)
        {
            InputCreateCustomer = inputCreateCustomer;
            ExistingCode = existingCode;
            RepeatedCode = repeatedCode;
            InvalidBirthDate = birthDate;
            return this;
        }

        public CustomerValidateDTO ValidateUpdate(InputIdentityUpdateCustomer inputIdentityUpdateCustomer, string existingCode, InputIdentityUpdateCustomer repeatedCodeUpdate, EnumValidateType birthDate)
        {
            InputIdentityUpdateCustomer = inputIdentityUpdateCustomer;
            ExistingCode = existingCode;
            RepeatedCodeUpdate = repeatedCodeUpdate;
            InvalidBirthDate = birthDate;
            return this;
        }

        public CustomerValidateDTO ValidateDelete(InputIdentityDeleteCustomer inputIdentityDeleteCustomer, CustomerDTO originalCustomer)
        {
            InputIdentityDeleteCustomer = inputIdentityDeleteCustomer;
            OriginalCustomer = originalCustomer;
            return this;
        }
    }
}