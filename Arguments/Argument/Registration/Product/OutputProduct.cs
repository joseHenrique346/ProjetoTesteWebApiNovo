using Arguments.Argument.Base;

namespace Arguments.Argument.Registration.Product
{
    public class OutputProduct : BaseOutput<OutputProduct>
    {
        #region Properties

        public long Id { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }
        public long BrandId { get; private set; }
        public long CategoryId { get; private set; }
        public decimal Price { get; private set; }
        public long Stock { get; private set; }

        #endregion

        #region Constructors

        public OutputProduct(string code, string description, long brandId, long categoryId, decimal price, long stock)
        {
            Code = code;
            Description = description;
            BrandId = brandId;
            CategoryId = categoryId;
            Price = price;
            Stock = stock;
        }

        public OutputProduct() { }

        #endregion
    }
}