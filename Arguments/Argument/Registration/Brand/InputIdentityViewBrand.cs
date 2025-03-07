using Arguments.Argument.Base.Crud;
using Arguments.Argument.Interface;

namespace Arguments.Argument.Registration.Brand
{
    public class InputIdentityViewBrand(long id) : BaseInputIdentityView<InputIdentityViewBrand>, IBaseIdentityView
    {
        public long Id { get; private set; } = id;
    }
}