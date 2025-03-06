using Domain.DTO.Entity.Product;
using Domain.Interface.Service.Product;
using Domain.Service.Base;
using Domain.Utils.Helper;

namespace Domain.Service.Registration.Product
{
    public class ProductValidateService : BaseValidateService<ProductValidateDTO>, IProductValidateService
    {
        public void Create(List<ProductValidateDTO> listProductValidateService)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listProductValidateService);
        }

        public void Update(List<ProductValidateDTO> listProductValidateService)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listProductValidateService);
        }

        public void Delete(List<ProductValidateDTO> listProductValidateService)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listProductValidateService);
        }
    }
}