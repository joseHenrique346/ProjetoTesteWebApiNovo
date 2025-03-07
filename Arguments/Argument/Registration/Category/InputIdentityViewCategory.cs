using Arguments.Argument.Base.Crud;
using Arguments.Argument.Interface;

namespace Arguments.Argument.Registration.Category
{
    public class InputIdentityViewCategory(long id) : BaseInputIdentityView<InputIdentityViewCategory>, IBaseIdentityView
    {
        public long Id { get; private set; } = id;
    }
}
