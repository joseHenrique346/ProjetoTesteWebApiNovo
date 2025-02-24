using Arguments.Argument.Enum;
using Domain.DTO.Entity.Customer;

namespace Domain.Interface.Service.Customer
{
    public interface ICustomerValidateService
    {
        public void Create(List<CustomerValidateDTO> listCustomerValidateDTO);
        public void Update(List<CustomerValidateDTO> listCustomerValidateDTO);
        public void Delete(List<CustomerValidateDTO> listCustomerValidateDTO);
        public EnumValidateType InvalidBirthDate(DateOnly? birthDate, int minAge);
    }
}