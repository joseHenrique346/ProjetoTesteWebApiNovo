using Domain.DTO.Entity.Category;

namespace Domain.Interface.Service.Category
{
    public interface ICategoryValidateService
    {
        void Create(List<CategoryValidateDTO> listInputCreateCategory);
        void Update(List<CategoryValidateDTO> listInputCreateCategory);
        void Delete(List<CategoryValidateDTO> listInputCreateCategory);
    }
}