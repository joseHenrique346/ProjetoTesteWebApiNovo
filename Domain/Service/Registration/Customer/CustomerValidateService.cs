using Arguments.Argument.Enum;
using Domain.DTO.Entity.Customer;
using Domain.Interface.Service.Customer;
using Domain.Service.Base;
using Domain.Utils.Helper;

namespace Domain.Service.Registration.Customer
{
    public class CustomerValidateService : BaseValidateService<CustomerValidateDTO>, ICustomerValidateService
    {
        public void Create(List<CustomerValidateDTO> listCustomerValidateDTO)
        {
            NotificationHelper.CreateNewDictionary();

            ValidateNullDTO(listCustomerValidateDTO);

            (from i in RemoveIgnore(listCustomerValidateDTO)
             where i.ExistingCode != null
             let setInvalid = i.SetInvalid()
             select AlreadyExists(i.InputCreateCustomer!.Code, EnumValidateType.Invalid)).ToList();

            (from i in RemoveIgnore(listCustomerValidateDTO)
             where i.RepeatedCode != null
             let setInvalid = i.SetInvalid()
             select RepeatedCode(i.InputCreateCustomer!.Code, EnumValidateType.Invalid)).ToList();

            (from i in RemoveIgnore(listCustomerValidateDTO)
             where i.InvalidBirthDate != EnumValidateType.Valid
             let birthDate = i.InputCreateCustomer.BirthDate
             let setInvalid = i.SetInvalid()
             select InvalidBirthDate(i.InputCreateCustomer!.Code, birthDate, EnumValidateType.Invalid, i.InputCreateCustomer!.FirstName)).ToList();

            (from i in RemoveIgnore(listCustomerValidateDTO)
             let code = i.InputCreateCustomer.Code
             let resultInvalidLenght = InvalidLenght(code, 1, 6)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(code, resultInvalidLenght, nameof(code), 1, 6)).ToList();

            (from i in RemoveIgnore(listCustomerValidateDTO)
             let firstName = i.InputCreateCustomer.FirstName
             let resultInvalidLenght = InvalidLenght(firstName, 1, 100)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateCustomer.Code, resultInvalidLenght, nameof(firstName), 1, 100)).ToList();

            (from i in RemoveIgnore(listCustomerValidateDTO)
             let lastName = i.InputCreateCustomer.LastName
             let resultInvalidLenght = InvalidLenght(lastName, 1, 100)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateCustomer.Code, resultInvalidLenght, nameof(lastName), 1, 100)).ToList();

            (from i in RemoveIgnore(listCustomerValidateDTO)
             let document = i.InputCreateCustomer.Document
             let resultInvalidLenght = InvalidLenght(document, 11)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateCustomer.Code, resultInvalidLenght, nameof(document), 11)).ToList();

            (from i in RemoveIgnore(listCustomerValidateDTO)
             let phone = i.InputCreateCustomer.Phone
             let resultInvalidLenght = InvalidLenght(phone, 11)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputCreateCustomer.Code, resultInvalidLenght, nameof(phone), 11)).ToList();
        }

        public void Update(List<CustomerValidateDTO> listCustomerValidateDTO)
        {
            NotificationHelper.CreateNewDictionary();

            ValidateNullDTO(listCustomerValidateDTO);

            (from i in RemoveIgnore(listCustomerValidateDTO)
             where i.ExistingCode != null
             let setInvalid = i.SetInvalid()
             select AlreadyExists(i.InputCreateCustomer!.Code, EnumValidateType.Invalid)).ToList();

            (from i in RemoveIgnore(listCustomerValidateDTO)
             where i.RepeatedCode != null
             let setInvalid = i.SetInvalid()
             select RepeatedCode(i.InputCreateCustomer!.Code, EnumValidateType.Invalid)).ToList();

            (from i in RemoveIgnore(listCustomerValidateDTO)
             where i.InvalidBirthDate != EnumValidateType.Valid
             let birthDate = i.InputIdentityUpdateCustomer.InputUpdateCustomer.BirthDate
             let setInvalid = i.SetInvalid()
             select InvalidBirthDate(i.InputCreateCustomer!.Code, birthDate, EnumValidateType.Invalid, i.InputCreateCustomer!.FirstName)).ToList();

            (from i in RemoveIgnore(listCustomerValidateDTO)
             let code = i.InputIdentityUpdateCustomer.InputUpdateCustomer.Code
             let resultInvalidLenght = InvalidLenght(code, 1, 6)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(code, resultInvalidLenght, nameof(code), 1, 6)).ToList();

            (from i in RemoveIgnore(listCustomerValidateDTO)
             let firstName = i.InputIdentityUpdateCustomer.InputUpdateCustomer.FirstName
             let resultInvalidLenght = InvalidLenght(firstName, 1, 100)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputIdentityUpdateCustomer.InputUpdateCustomer.Code, resultInvalidLenght, nameof(firstName), 1, 100)).ToList();

            (from i in RemoveIgnore(listCustomerValidateDTO)
             let lastName = i.InputIdentityUpdateCustomer.InputUpdateCustomer.LastName
             let resultInvalidLenght = InvalidLenght(lastName, 1, 100)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputIdentityUpdateCustomer.InputUpdateCustomer.Code, resultInvalidLenght, nameof(lastName), 1, 100)).ToList();

            (from i in RemoveIgnore(listCustomerValidateDTO)
             let document = i.InputIdentityUpdateCustomer.InputUpdateCustomer.Document
             let resultInvalidLenght = InvalidLenght(document, 11)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputIdentityUpdateCustomer.InputUpdateCustomer.Code, resultInvalidLenght, nameof(document), 11)).ToList();

            (from i in RemoveIgnore(listCustomerValidateDTO)
             let phone = i.InputIdentityUpdateCustomer.InputUpdateCustomer.Phone
             let resultInvalidLenght = InvalidLenght(phone, 11)
             where resultInvalidLenght != EnumValidateType.Valid
             let setInvalid = i.SetInvalid()
             select InvalidLenght(i.InputIdentityUpdateCustomer.InputUpdateCustomer.Code, resultInvalidLenght, nameof(phone), 11)).ToList();
        }

        public void Delete(List<CustomerValidateDTO> listCustomerValidateDTO)
        {
            ValidateNullDTO(listCustomerValidateDTO);
        }

        public EnumValidateType InvalidBirthDate(DateOnly? birthDate, int minAge)
        {
            if (!birthDate.HasValue)
                return EnumValidateType.NonInformed;

            if (birthDate > DateOnly.FromDateTime(DateTime.Today))
                return EnumValidateType.Invalid;

            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Value.Year;

            if (birthDate.Value > DateOnly.FromDateTime(today.AddYears(-age))) age--;

            if (age < minAge)
                return EnumValidateType.Invalid;

            return EnumValidateType.Valid;
        }
    }
}