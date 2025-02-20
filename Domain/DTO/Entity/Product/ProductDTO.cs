using Domain.DTO.Base;
using Domain.DTO.Entity.Brand;
using Domain.DTO.Entity.Category;

namespace Domain.DTO.Entity.Product
{
    public class ProductDTO : BaseDTO
    {
        #region Properties

        public string Code { get; set; }
        public string Description { get; set; }
        public long BrandId { get; set; }
        public long CategoryId { get; set; }
        public decimal Price { get; set; }
        public long Stock { get; set; }
        #endregion

        #region Constructors
        public ProductDTO(string code, string description, long brandId, long categoryId, decimal price, long stock)
        {
            Code = code;
            Description = description;
            BrandId = brandId;
            CategoryId = categoryId;
            Price = price;
            Stock = stock;
        }
        public ProductDTO() { }
        #endregion

        #region Internal

        public virtual BrandDTO? BrandDTO { get; set; }
        public virtual CategoryDTO? CategoryDTO { get; set; }

        #endregion
    }
}