using Domain.DTO.Entity.Brand;

namespace Domain.Interface.Service
{
    public interface IBrandValidateService 
    {
        void Create(List<BrandValidateDTO> listBrandValidateDTO);
        void Update(List<BrandValidateDTO> listBrandValidateDTO);
        void Delete(List<BrandValidateDTO> listBrandValidateDTO);
    }
}