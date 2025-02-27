using Arguments.Argument.Registration.Product;
using Domain.DTO.Base;
using Domain.DTO.Entity.Brand;
using Domain.DTO.Entity.Category;

namespace Domain.DTO.Entity.Product
{
    public class ProductValidateDTO : BaseValidateDTO
    {
        public InputCreateProduct InputCreateProduct { get; set; }
        public BrandDTO OriginalBrand { get; set; }
        public CategoryDTO OriginalCategory { get; set; }

        public InputUpdateProduct InputUpdateProduct { get; set; }
        public ProductDTO OriginalProduct { get; set; }

        public InputIdentityUpdateProduct InputIdentityUpdateProduct { get; set; }
        public InputIdentityDeleteProduct InputIdentityDeleteProduct { get; set; }

        public ProductValidateDTO ValidateCreate(InputCreateProduct inputCreateProduct, BrandDTO originalBrand, CategoryDTO originalCategory)
        {
            InputCreateProduct = inputCreateProduct;
            OriginalBrand = originalBrand;
            OriginalCategory = originalCategory;
            return this;
        }

        public ProductValidateDTO ValidateUpdate(InputIdentityUpdateProduct inputIdentityUpdateProduct, ProductDTO originalProduct, BrandDTO originalBrand, CategoryDTO originalCategory)
        {
            InputIdentityUpdateProduct = inputIdentityUpdateProduct;
            OriginalProduct = originalProduct;
            OriginalBrand = originalBrand;
            OriginalCategory = originalCategory;
            return this;
        }

        public ProductValidateDTO ValidateDelete(InputIdentityDeleteProduct inputIdentityDeleteProduct, ProductDTO originalProduct)
        {
            InputIdentityDeleteProduct = inputIdentityDeleteProduct;
            OriginalProduct = originalProduct;
            return this;
        }
    }
}