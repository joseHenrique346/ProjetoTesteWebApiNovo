using Domain.DTO.Base;

namespace Domain.DTO.Entity
{
    public class BrandDTO : BaseDTO
    {
        #region Properties
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public List<ProductDTO> ListProduct { get; set; }
        #endregion

        #region Constructors
        public BrandDTO(string name, string code, string description, List<ProductDTO> listProduct)
        {
            Name = name;
            Code = code;
            Description = description;
            ListProduct = listProduct;
        }
        public BrandDTO() { }
        #endregion
    }
}