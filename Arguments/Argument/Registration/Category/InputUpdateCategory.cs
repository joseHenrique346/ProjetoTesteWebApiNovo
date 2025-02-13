namespace Arguments.Argument.Registration.Category
{
    public class InputUpdateCategory(string description, string code)
    {
        public string Description { get; private set; } = description;
        public string Code { get; private set; } = code;
    }
}
