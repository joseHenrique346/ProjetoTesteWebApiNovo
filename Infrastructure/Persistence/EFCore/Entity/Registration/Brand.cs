using Infrastructure.Persistence.EFCore.Entity.Base;

namespace Infrastructure.Persistence.EFCore.Entity.Registration
{
    public class Brand : BaseEntity
    {
        #region Properties
        public string Code { get; set; }
        public string Description { get; set; }
        public List<Product> ListProduct { get; set; }
        #endregion

        #region Constructors
        public Brand(string code, string description, List<Product> listProduct)
        {
            Code = code;
            Description = description;
            ListProduct = listProduct;
        }
        public Brand() { }
        #endregion
    }
}