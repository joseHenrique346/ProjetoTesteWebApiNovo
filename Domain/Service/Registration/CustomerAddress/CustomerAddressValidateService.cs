using Arguments.Argument.Enum;
using Domain.DTO.Entity.CustomerAddress;
using Domain.Interface.Service.CustomerAddress;
using Domain.Service.Base;
using Domain.Utils.Helper;

namespace Domain.Service.Registration.CustomerAddress
{
    public class CustomerAddressValidateService : BaseValidateService<CustomerAddressValidateDTO>, ICustomerAddressValidateService
    {
        public void Create(List<CustomerAddressValidateDTO> listCustomerAddressValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listCustomerAddressValidateDTO);

            (from i in RemoveIgnore(listCustomerAddressValidateDTO)
             let resultInvalidRelatedProperty = InvalidRelatedProperty(i.RelatedCustomerDTO, i.InputCreateCustomerAddress!.CustomerId)
             where i.RelatedCustomerDTO == null
             let setIgnore = i.SetIgnore()
             select resultInvalidRelatedProperty).ToList();

            (from i in RemoveIgnore(listCustomerAddressValidateDTO)
             let resultInvalidLength = InvalidLenght(i.InputCreateCustomerAddress.PostalCode, 1, 8)
             where resultInvalidLength != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateCustomerAddress.Number, EnumValidateType.Invalid, nameof(i.InputCreateCustomerAddress.PostalCode), 1, 8)).ToList();

            (from i in RemoveIgnore(listCustomerAddressValidateDTO)
             let resultInvalidLength = InvalidLenght(i.InputCreateCustomerAddress.Reference, 0, 100)
             where resultInvalidLength != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateCustomerAddress.Number, EnumValidateType.Invalid, nameof(i.InputCreateCustomerAddress.Reference), 0, 100)).ToList();

            (from i in RemoveIgnore(listCustomerAddressValidateDTO)
             let resultInvalidLength = InvalidLenght(i.InputCreateCustomerAddress.Complement, 0, 100)
             where resultInvalidLength != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateCustomerAddress.Number, EnumValidateType.Invalid, nameof(i.InputCreateCustomerAddress.Complement), 0, 100)).ToList();

            (from i in RemoveIgnore(listCustomerAddressValidateDTO)
             let resultInvalidLength = InvalidLenght(i.InputCreateCustomerAddress.Neighborhood, 1, 100)
             where resultInvalidLength != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateCustomerAddress.Number, EnumValidateType.Invalid, nameof(i.InputCreateCustomerAddress.Neighborhood), 1, 100)).ToList();
        }

        public void Update(List<CustomerAddressValidateDTO> listCustomerAddressValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listCustomerAddressValidateDTO);

            //existing

            (from i in RemoveIgnore(listCustomerAddressValidateDTO)
             let inputUpdate = i.InputIdentityUpdateCustomerAddress.InputUpdateCustomerAddress
             let resultInvalidLength = InvalidLenght(inputUpdate.PostalCode, 1, 8)
             where resultInvalidLength != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(inputUpdate.Number, EnumValidateType.Invalid, nameof(inputUpdate.PostalCode), 1, 8)).ToList();

            (from i in RemoveIgnore(listCustomerAddressValidateDTO)
             let inputUpdate = i.InputIdentityUpdateCustomerAddress.InputUpdateCustomerAddress
             let resultInvalidLength = InvalidLenght(i.InputCreateCustomerAddress.Reference, 0, 100)
             where resultInvalidLength != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(inputUpdate.Number, EnumValidateType.Invalid, nameof(inputUpdate.Reference), 0, 100)).ToList();

            (from i in RemoveIgnore(listCustomerAddressValidateDTO)
             let resultInvalidLength = InvalidLenght(i.InputCreateCustomerAddress.Complement, 0, 100)
             where resultInvalidLength != EnumValidateType.Valid
             let inputUpdate = i.InputIdentityUpdateCustomerAddress.InputUpdateCustomerAddress
             let setInvalid = i.SetInvalid()
             select InvalidLenght(inputUpdate.Number, EnumValidateType.Invalid, nameof(inputUpdate.Complement), 0, 100)).ToList();

            (from i in RemoveIgnore(listCustomerAddressValidateDTO)
             let resultInvalidLength = InvalidLenght(i.InputCreateCustomerAddress.Neighborhood, 1, 100)
             let inputUpdate = i.InputIdentityUpdateCustomerAddress.InputUpdateCustomerAddress
             where resultInvalidLength != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(inputUpdate.Number, EnumValidateType.Invalid, nameof(inputUpdate.Neighborhood), 1, 100)).ToList();
        }

        public void Delete(List<CustomerAddressValidateDTO> listCustomerAddressValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listCustomerAddressValidateDTO);
        }
    }
}
