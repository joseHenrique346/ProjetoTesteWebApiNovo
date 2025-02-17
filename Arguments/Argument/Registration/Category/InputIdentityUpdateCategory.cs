using Arguments.Argument.Base.Crud;

namespace Arguments.Argument.Registration.Category
{
    public class InputIdentityUpdateCategory(long id, InputUpdateCategory inputUpdateCategory) : BaseInputIdentityUpdate<InputIdentityUpdateCategory>
    {
        public long Id { get; private set; } = id;
        public InputUpdateCategory InputUpdateCategory { get; private set; } = inputUpdateCategory;
    }
}
