using Arguments.Argument.Base.Crud;

namespace Arguments.Argument.Registration.Category
{
    public class InputIdentityDeleteCategory(long id) : BaseInputIdentityDelete<InputIdentityDeleteCategory>
    {
        public long Id { get; private set; } = id;
    }
}
