using Arguments.Argument.Enum;
using Arguments.Argument.Registration.Customer;
using Domain.DTO.Base;

namespace Domain.DTO.Entity.Customer
{
    public class CustomerValidateDTO : BaseValidateDTO
    {
        public InputCreateCustomer InputCreate { get; private set; }
        public string ExistingCode { get; set; }
        public InputCreateCustomer? RepeatedCode { get; set; }
        public EnumValidateType InvalidBirthDate { get; set; }

        public InputUpdateCustomer InputUpdate { get; private set; }
        public InputIdentityUpdateCustomer? RepeatedCodeUpdate { get; set; }

        public InputIdentityUpdateCustomer InputIdentityUpdateCustomer { get; private set; }
        public InputIdentityDeleteCustomer InputIdentityDeleteCustomer { get; private set; }
        public CustomerDTO OriginalCustomer { get; set; }

        public CustomerValidateDTO ValidateCreate(InputCreateCustomer inputCreate, string existingCode, InputCreateCustomer? repeatedCode, EnumValidateType birthDate)
        {
            InputCreate = inputCreate;
            ExistingCode = existingCode;
            RepeatedCode = repeatedCode;
            InvalidBirthDate = birthDate;
            return this;
        }

        public CustomerValidateDTO ValidateUpdate(InputUpdateCustomer inputUpdate, string existingCode, InputIdentityUpdateCustomer repeatedCodeUpdate, EnumValidateType birthDate)
        {
            InputUpdate = inputUpdate;
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