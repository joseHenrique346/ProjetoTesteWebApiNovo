using Arguments.Argument.Base.Crud;
using Arguments.Argument.Interface;

namespace Arguments.Argument.Registration.Product
{
    public class InputIdentityViewProduct : BaseInputIdentityView<InputIdentityViewProduct>, IBaseIdentityView
    {
        public long Id { get; private set; }
    }
}
