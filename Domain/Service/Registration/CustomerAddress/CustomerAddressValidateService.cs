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
            NotificationHelper.CreateNewDictionary();

            ValidateNullDTO(listCustomerAddressValidateDTO);

            (from i in RemoveIgnore(listCustomerAddressValidateDTO)
             let resultInvalidRelatedProperty = InvalidRelatedProperty(i.RelatedCustomerDTO, i.InputCreateCustomerAddress!.CustomerId)
             where i.RelatedCustomerDTO == null
             let setIgnore = i.SetIgnore()
             select resultInvalidRelatedProperty).ToList();

            (from i in RemoveIgnore(listCustomerAddressValidateDTO)
             let resultInvalidLenght = InvalidLenght(i.InputCreateCustomerAddress.PostalCode, 1, 8)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateCustomerAddress.Number, EnumValidateType.Invalid, nameof(i.InputCreateCustomerAddress.PostalCode), 1, 8)).ToList();

            (from i in RemoveIgnore(listCustomerAddressValidateDTO)
             let resultInvalidLenght = InvalidLenght(i.InputCreateCustomerAddress.Reference, 0, 100)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateCustomerAddress.Number, EnumValidateType.Invalid, nameof(i.InputCreateCustomerAddress.Reference), 0, 100)).ToList();

            (from i in RemoveIgnore(listCustomerAddressValidateDTO)
             let resultInvalidLenght = InvalidLenght(i.InputCreateCustomerAddress.Complement, 0, 100)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateCustomerAddress.Number, EnumValidateType.Invalid, nameof(i.InputCreateCustomerAddress.Complement), 0, 100)).ToList();

            (from i in RemoveIgnore(listCustomerAddressValidateDTO)
             let resultInvalidLenght = InvalidLenght(i.InputCreateCustomerAddress.Neighborhood, 1, 100)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateCustomerAddress.Number, EnumValidateType.Invalid, nameof(i.InputCreateCustomerAddress.Neighborhood), 1, 100)).ToList();
        }

        public void Update(List<CustomerAddressValidateDTO> listCustomerAddressValidateDTO)
        {
            NotificationHelper.CreateNewDictionary();

            ValidateNullDTO(listCustomerAddressValidateDTO);

            //existing

            (from i in RemoveIgnore(listCustomerAddressValidateDTO)
             let inputUpdate = i.InputIdentityUpdateCustomerAddress.InputUpdateCustomerAddress
             let resultInvalidLenght = InvalidLenght(inputUpdate.PostalCode, 1, 8)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(inputUpdate.Number, EnumValidateType.Invalid, nameof(inputUpdate.PostalCode), 1, 8)).ToList();

            (from i in RemoveIgnore(listCustomerAddressValidateDTO)
             let inputUpdate = i.InputIdentityUpdateCustomerAddress.InputUpdateCustomerAddress
             let resultInvalidLenght = InvalidLenght(i.InputCreateCustomerAddress.Reference, 0, 100)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(inputUpdate.Number, EnumValidateType.Invalid, nameof(inputUpdate.Reference), 0, 100)).ToList();

            (from i in RemoveIgnore(listCustomerAddressValidateDTO)
             let resultInvalidLenght = InvalidLenght(i.InputCreateCustomerAddress.Complement, 0, 100)
             where resultInvalidLenght != EnumValidateType.Valid
             let inputUpdate = i.InputIdentityUpdateCustomerAddress.InputUpdateCustomerAddress
             let setInvalid = i.SetInvalid()
             select InvalidLenght(inputUpdate.Number, EnumValidateType.Invalid, nameof(inputUpdate.Complement), 0, 100)).ToList();

            (from i in RemoveIgnore(listCustomerAddressValidateDTO)
             let resultInvalidLenght = InvalidLenght(i.InputCreateCustomerAddress.Neighborhood, 1, 100)
             let inputUpdate = i.InputIdentityUpdateCustomerAddress.InputUpdateCustomerAddress
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(inputUpdate.Number, EnumValidateType.Invalid, nameof(inputUpdate.Neighborhood), 1, 100)).ToList();
        }

        public void Delete(List<CustomerAddressValidateDTO> listCustomerAddressValidateDTO)
        {
            ValidateNullDTO(listCustomerAddressValidateDTO);
        }
    }
}
