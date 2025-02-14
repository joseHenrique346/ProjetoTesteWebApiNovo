using Arguments.Argument.Base;

namespace Arguments.Argument.Registration.Brand
{
    public class InputIdentityDeleteBrand(long id) : BaseInputIdentityDelete<InputIdentityDeleteBrand>
    {
        public long Id { get; private set; } = id;
    }
}
