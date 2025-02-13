namespace Arguments.Argument.Registration.Product
{
    public class OutputProduct(string code, string description, long brandId, long categoryId, decimal price, long stock)
    {
        public string Code { get; private set; } = code;
        public string Description { get; private set; } = description;
        public long BrandId { get; private set; } = brandId;
        public long CategoryId { get; private set; } = categoryId;
        public decimal Price { get; private set; } = price;
        public long Stock { get; private set; } = stock;
    }
}