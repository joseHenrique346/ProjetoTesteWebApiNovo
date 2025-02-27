using Domain.DTO.Entity.Product;
using Domain.Interface.Service.Product;
using Domain.Service.Base;

namespace Domain.Service.Registration.Product
{
    public class ProductValidateService : BaseValidateService<ProductValidateDTO>, IProductValidateService
    {
        public void Create(List<ProductValidateDTO> listProductValidateService)
        {
            ValidateNullDTO(listProductValidateService);
        }

        public void Update(List<ProductValidateDTO> listProductValidateService)
        {
            ValidateNullDTO(listProductValidateService);
        }

        public void Delete(List<ProductValidateDTO> listProductValidateService)
        {
            ValidateNullDTO(listProductValidateService);
        }
    }
}