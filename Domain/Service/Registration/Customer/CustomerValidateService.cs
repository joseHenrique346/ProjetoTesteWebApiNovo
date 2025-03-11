using Arguments.Argument.Enum;
using Domain.DTO.Entity.Customer;
using Domain.Interface.Service.Customer;
using Domain.Service.Base;
using Domain.Utils.Helper;

namespace Domain.Service.Registration.Customer
{
    public class CustomerValidateService : BaseValidateService<CustomerValidateDTO>, ICustomerValidateService
    {
        public void Create(List<CustomerValidateDTO> listValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listValidateDTO);

            (from i in RemoveIgnore(listValidateDTO)
             where i.ExistingCode != null
             let setInvalid = i.SetInvalid()
             select AlreadyExists(i.InputCreate!.Code)).ToList();

            (from i in RemoveIgnore(listValidateDTO)
             where i.RepeatedCode != null
             let setInvalid = i.SetInvalid()
             let index = listValidateDTO.IndexOf(i)
             select RepeatedCode(i.InputCreate!.Code)).ToList();

            (from i in RemoveIgnore(listValidateDTO)
             where i.InvalidBirthDate != EnumValidateType.Valid
             let birthDate = i.InputCreate.BirthDate
             let setInvalid = i.SetInvalid()
             select InvalidBirthDate(i.InputCreate!.Code, birthDate, i.InputCreate!.FirstName)).ToList();

            //InvalidLengthValidation(listValidateDTO, "Code", "InputCreate", 1, 6);
            //InvalidLengthValidation(listValidateDTO, "FirstName", "InputCreate", 1, 100);
            //InvalidLengthValidation(listValidateDTO, "LastName", "InputCreate", 1, 100);
            //InvalidLengthValidation(listValidateDTO, "Document", "InputCreate", 11, 11);
            //InvalidLengthValidation(listValidateDTO, "Phone", "InputCreate", 11, 11);

            //(from i in RemoveIgnore(listCustomerValidateDTO)
            // let code = i.InputCreate.Code
            // let resultInvalidLength= InvalidLenght(code, 1, 6)
            // where resultInvalidLength!= EnumValidateType.Valid
            // let setInvalid = i.SetInvalid()
            // select InvalidLenght(code, resultInvalidLength, nameof(code), 1, 6)).ToList();

            //(from i in RemoveIgnore(listCustomerValidateDTO)
            // let firstName = i.InputCreate.FirstName
            // let resultInvalidLength= InvalidLenght(firstName, 1, 100)
            // where resultInvalidLength!= EnumValidateType.Valid
            // let setInvalid = i.SetInvalid()
            // select InvalidLenght(i.InputCreate.Code, resultInvalidLength, nameof(firstName), 1, 100)).ToList();

            //(from i in RemoveIgnore(listCustomerValidateDTO)
            // let lastName = i.InputCreate.LastName
            // let resultInvalidLength= InvalidLenght(lastName, 1, 100)
            // where resultInvalidLength!= EnumValidateType.Valid
            // let setInvalid = i.SetInvalid()
            // select InvalidLenght(i.InputCreate.Code, resultInvalidLength, nameof(lastName), 1, 100)).ToList();

            //(from i in RemoveIgnore(listCustomerValidateDTO)
            // let document = i.InputCreate.Document
            // let resultInvalidLength= InvalidLenght(document, 11)
            // where resultInvalidLength!= EnumValidateType.Valid
            // let setInvalid = i.SetInvalid()
            // select InvalidLenght(i.InputCreate.Code, resultInvalidLength, nameof(document), 11)).ToList();

            //(from i in RemoveIgnore(listCustomerValidateDTO)
            // let phone = i.InputCreate.Phone
            // let resultInvalidLength= InvalidLenght(phone, 11)
            // where resultInvalidLength!= EnumValidateType.Valid
            // let setInvalid = i.SetInvalid()
            // select InvalidLenght(i.InputCreate.Code, resultInvalidLength, nameof(phone), 11)).ToList();
        }

        public void Update(List<CustomerValidateDTO> listValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listValidateDTO);

            (from i in RemoveIgnore(listValidateDTO)
             where i.ExistingCode != null
             let setInvalid = i.SetInvalid()
             select AlreadyExists(i.InputCreate!.Code)).ToList();

            (from i in RemoveIgnore(listValidateDTO)
             where i.RepeatedCode != null
             let setInvalid = i.SetInvalid()
             let index = listValidateDTO.IndexOf(i)
             select RepeatedCode(i.InputCreate!.Code)).ToList();

            (from i in RemoveIgnore(listValidateDTO)
             where i.InvalidBirthDate != EnumValidateType.Valid
             let birthDate = i.InputIdentityUpdateCustomer.InputUpdateCustomer.BirthDate
             let setInvalid = i.SetInvalid()
             select InvalidBirthDate(i.InputCreate!.Code, birthDate, i.InputCreate!.FirstName)).ToList();

            //InvalidLengthValidation(listValidateDTO, "Code", "InputUpdate", 1, 6);
            //InvalidLengthValidation(listValidateDTO, "FirstName", "InputUpdate", 1, 100);
            //InvalidLengthValidation(listValidateDTO, "LastName", "InputUpdate", 1, 100);
            //InvalidLengthValidation(listValidateDTO, "Document", "InputUpdate", 11, 11);
            //InvalidLengthValidation(listValidateDTO, "Phone", "InputUpdate", 11, 11);

            //(from i in RemoveIgnore(listCustomerValidateDTO)
            // let code = i.InputIdentityUpdateCustomer.InputUpdateCustomer.Code
            // let resultInvalidLength= InvalidLenght(code, 1, 6)
            // where resultInvalidLength!= EnumValidateType.Valid
            // let setInvalid = i.SetInvalid()
            // select InvalidLenght(code, resultInvalidLength, nameof(code), 1, 6)).ToList();

            //(from i in RemoveIgnore(listCustomerValidateDTO)
            // let firstName = i.InputIdentityUpdateCustomer.InputUpdateCustomer.FirstName
            // let resultInvalidLength= InvalidLenght(firstName, 1, 100)
            // where resultInvalidLength!= EnumValidateType.Valid
            // let setInvalid = i.SetInvalid()
            // select InvalidLenght(i.InputIdentityUpdateCustomer.InputUpdateCustomer.Code, resultInvalidLength, nameof(firstName), 1, 100)).ToList();

            //(from i in RemoveIgnore(listCustomerValidateDTO)
            // let lastName = i.InputIdentityUpdateCustomer.InputUpdateCustomer.LastName
            // let resultInvalidLength= InvalidLenght(lastName, 1, 100)
            // where resultInvalidLength!= EnumValidateType.Valid
            // let setInvalid = i.SetInvalid()
            // select InvalidLenght(i.InputIdentityUpdateCustomer.InputUpdateCustomer.Code, resultInvalidLength, nameof(lastName), 1, 100)).ToList();

            //(from i in RemoveIgnore(listCustomerValidateDTO)
            // let document = i.InputIdentityUpdateCustomer.InputUpdateCustomer.Document
            // let resultInvalidLength= InvalidLenght(document, 11)
            // where resultInvalidLength!= EnumValidateType.Valid
            // let setInvalid = i.SetInvalid()
            // select InvalidLenght(i.InputIdentityUpdateCustomer.InputUpdateCustomer.Code, resultInvalidLength, nameof(document), 11)).ToList();

            //(from i in RemoveIgnore(listCustomerValidateDTO)
            // let phone = i.InputIdentityUpdateCustomer.InputUpdateCustomer.Phone
            // let resultInvalidLength= InvalidLenght(phone, 11)
            // where resultInvalidLength!= EnumValidateType.Valid
            // let setInvalid = i.SetInvalid()
            // select InvalidLenght(i.InputIdentityUpdateCustomer.InputUpdateCustomer.Code, resultInvalidLength, nameof(phone), 11)).ToList();
        }

        public void Delete(List<CustomerValidateDTO> listCustomerValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

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