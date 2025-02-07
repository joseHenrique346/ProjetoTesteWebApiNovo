using Infrastructure.Persistence.EFCore.Entity.Base;

namespace Infrastructure.Persistence.EFCore.Entity.Registration
{
    public class Product : BaseEntity
    {
        #region Properties

        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public long BrandId { get; set; }
        public long CategoryId { get; set; }
        public decimal Price { get; set; }
        public long Stock { get; set; }
        #endregion

        #region Constructors
        public Product(string name, string code, string description, long brandId, long categoryId, decimal price, long stock)
        {
            Name = name;
            Code = code;
            Description = description;
            BrandId = brandId;
            CategoryId = categoryId;
            Price = price;
            Stock = stock;
        }
        public Product() { }
        #endregion

        #region Internal

        public virtual Brand? Brand { get; set; }
        public virtual Category? Category { get; set; }

        #endregion
    }
}
