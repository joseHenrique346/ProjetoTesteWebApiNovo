using Arguments.Argument.Base.Crud;

namespace Arguments.Argument.Registration.Category
{
    public class InputIdentityViewCategory(long id) : BaseInputIdentityView<InputIdentityViewCategory>
    {
        public long Id { get; private set; } = id;
    }
}
