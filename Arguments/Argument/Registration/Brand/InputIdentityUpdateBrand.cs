using Arguments.Argument.Base;

namespace Arguments.Argument.Registration.Brand
{
    public class InputIdentityUpdateBrand(long id, InputUpdateBrand inputUpdateBrand) : BaseInputIdentityUpdate<InputIdentityUpdateBrand>
    {
        public long Id { get; private set; } = id;
        public InputUpdateBrand InputUpdateBrand { get; private set; } = inputUpdateBrand;
    }
}