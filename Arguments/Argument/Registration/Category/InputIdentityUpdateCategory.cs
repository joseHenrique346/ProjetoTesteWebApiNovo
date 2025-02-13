
namespace Arguments.Argument.Registration.Category
{
    public class InputIdentityUpdateCategory(long id, InputUpdateCategory inputUpdateCategory)
    {
        public long Id { get; private set; } = id;
        public InputUpdateCategory InputUpdateCategory { get; private set; } = inputUpdateCategory;
    }
}
