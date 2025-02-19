using Arguments.Argument.Base.Crud;

namespace Arguments.Argument.Registration.Product
{
    public class InputIdentityDeleteProduct : BaseInputIdentityDelete<InputIdentityDeleteProduct>
    {
        public long Id { get; private set; }
    }
}