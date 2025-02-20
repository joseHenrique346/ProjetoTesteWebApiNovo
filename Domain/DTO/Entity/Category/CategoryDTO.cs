using Domain.DTO.Base;
using Domain.DTO.Entity.Product;

namespace Domain.DTO.Entity.Category
{
    public class CategoryDTO : BaseDTO
    {
        #region Properties

        public string Code { get; set; }
        public string Description { get; set; }
        public List<ProductDTO> ListProduct { get; set; }

        #endregion

        #region Constructors
        public CategoryDTO(string code, string description)
        {
            Code = code;
            Description = description;
        }
        public CategoryDTO() { }
        #endregion
    }
}