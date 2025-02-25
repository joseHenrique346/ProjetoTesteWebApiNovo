using Domain.DTO.Entity.CustomerAddress;

namespace Domain.Interface.Service.CustomerAddress
{
    public interface ICustomerAddressValidateService
    {
        public void Create(List<CustomerAddressValidateDTO> listCustomerAddressValidateDTO);
        public void Update(List<CustomerAddressValidateDTO> listCustomerAddressValidateDTO);
    }
}