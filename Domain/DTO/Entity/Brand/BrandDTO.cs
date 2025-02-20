using Domain.DTO.Base;
using Domain.DTO.Entity.Product;

namespace Domain.DTO.Entity.Brand
{
    public class BrandDTO : BaseDTO
    {
        #region Properties
        public string Code { get; set; }
        public string Description { get; set; }
        public List<ProductDTO>? ListProduct { get; set; }
        #endregion

        #region Constructors
        public BrandDTO(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public BrandDTO(string code, string description, List<ProductDTO> listProduct)
        {
            Code = code;
            Description = description;
            ListProduct = listProduct;
        }
        public BrandDTO() { }
        #endregion
    }
}