using Arguments.Argument.Base.Crud;
using System.ComponentModel.DataAnnotations;

namespace Arguments.Argument.Registration.Product
{
    public class InputCreateProduct(string code, string description, long brandId, long categoryId, decimal price, long stock) : BaseInputCreate<InputCreateProduct>
    {
        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        public string Code { get; private set; } = code;

        public string Description { get; private set; } = description;
        public long BrandId { get; private set; } = brandId;
        public long CategoryId { get; private set; } = categoryId;
        public decimal Price { get; private set; } = price;
        public long Stock { get; private set; } = stock;
    }
}