using Arguments.Argument.Registration.CustomerAddress;
using Domain.DTO.Entity.CustomerAddress;
using Domain.Interface.Service.CustomerAddress;
using Domain.Service.Base;
using Domain.Utils.Helper;

namespace Domain.Service.Registration.CustomerAddress
{
    public class CustomerAddressValidateService : BaseValidateService<CustomerAddressValidateDTO, InputCreateCustomerAddress, InputUpdateCustomerAddress, InputIdentityDeleteCustomerAddress>, ICustomerAddressValidateService
    {
        public void Create(List<CustomerAddressValidateDTO> listCustomerAddressValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listCustomerAddressValidateDTO);

            ValidateNullInput(listCustomerAddressValidateDTO);

            ValidateNullCode(listCustomerAddressValidateDTO);

            //(from i in RemoveIgnore(listCustomerAddressValidateDTO)
            // let resultInvalidRelatedProperty = InvalidRelatedProperty(i.RelatedCustomerDTO, i.InputCreateCustomerAddress!.CustomerId)
            // where i.RelatedCustomerDTO == null
            // let setIgnore = i.SetIgnore()
            // select resultInvalidRelatedProperty).ToList();

            //Existing Code e Repeated Code

            (from i in listCustomerAddressValidateDTO
             let validateInvalidLengthPostalCode = InvalidLengthValidation(i, "PostalCode", "Code", 1, 8)
             let validateInvalidLengthReference = InvalidLengthValidation(i, "Reference", "Code", 0, 100)
             let validateInvalidLengthComplement = InvalidLengthValidation(i, "Complement", "Code", 0, 100)
             let validateInvalidLengthNeighborhood = InvalidLengthValidation(i, "Neighborhood", "Code", 1, 100)
             select true).ToList();
        }

        public void Update(List<CustomerAddressValidateDTO> listCustomerAddressValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listCustomerAddressValidateDTO);

            ValidateNullInput(listCustomerAddressValidateDTO);

            ValidateNullCode(listCustomerAddressValidateDTO);

            //existing

            (from i in listCustomerAddressValidateDTO
             let validateInvalidLengthPostalCode = InvalidLengthValidation(i, "PostalCode", "Code", 1, 8)
             let validateInvalidLengthReference = InvalidLengthValidation(i, "Reference", "Code", 0, 100)
             let validateInvalidLengthComplement = InvalidLengthValidation(i, "Complement", "Code", 0, 100)
             let validateInvalidLengthNeighborhood = InvalidLengthValidation(i, "Neighborhood", "Code", 1, 100)
             select true).ToList();
        }

        public void Delete(List<CustomerAddressValidateDTO> listCustomerAddressValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listCustomerAddressValidateDTO);
        }
    }
}
