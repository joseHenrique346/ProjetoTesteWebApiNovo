using Domain.DTO.Entity.Product;

namespace Domain.Interface.Service.Product
{
    public interface IProductValidateService
    {
        public void Create(List<ProductValidateDTO> listProductValidateDTO);
        public void Update(List<ProductValidateDTO> listProductValidateDTO);
        public void Delete(List<ProductValidateDTO> listProductValidateDTO);
    }
}