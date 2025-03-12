using Arguments.Argument.Registration.Product;
using Domain.DTO.Entity.Product;
using Domain.Interface.Service.Product;
using Domain.Service.Base;
using Domain.Utils.Helper;

namespace Domain.Service.Registration.Product
{
    public class ProductValidateService : BaseValidateService<ProductValidateDTO, InputCreateProduct, InputUpdateProduct, InputIdentityDeleteProduct>, IProductValidateService
    {
        public void Create(List<ProductValidateDTO> listProductValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listProductValidateDTO);

            ValidateNullInput(listProductValidateDTO);

            ValidateNullCode(listProductValidateDTO);
        }

        public void Update(List<ProductValidateDTO> listProductValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listProductValidateDTO);

            ValidateNullInput(listProductValidateDTO);

            ValidateNullCode(listProductValidateDTO);
        }

        public void Delete(List<ProductValidateDTO> listProductValidateDTO)
        {
            NotificationBuilder.CreateDictionary();

            ValidateNullDTO(listProductValidateDTO);
        }
    }
}