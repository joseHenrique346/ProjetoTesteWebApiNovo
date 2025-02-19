using Arguments.Argument.Registration.Product;

namespace Domain.DTO.Entity.Product
{
    public class ProductValidateDTO
    {
        public InputCreateProduct InputCreateProduct { get; set; }
        public InputUpdateProduct InputUpdateProduct { get; set; }
        public InputIdentityUpdateProduct InputIdentityUpdateProduct { get; set; }
        public InputIdentityDeleteProduct InputIdentityDeleteProduct { get; set; }
    }
}