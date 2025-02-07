using Infrastructure.Persistence.EFCore.Entity.Base;

namespace Infrastructure.Persistence.EFCore.Entity.Registration
{
    public class Brand : BaseEntity
    {
        #region Properties
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public List<Product> ListProduct { get; set; }
        #endregion

        #region Constructors
        public Brand(string name, string code, string description, List<Product> listProduct)
        {
            Name = name;
            Code = code;
            Description = description;
            ListProduct = listProduct;
        }
        public Brand() { }
        #endregion
    }
}