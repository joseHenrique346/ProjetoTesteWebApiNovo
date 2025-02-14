using Arguments.Argument.Base;

namespace Arguments.Argument.Registration.Category
{
    public class InputCreateCategory(string description, string code) : BaseInputCreate<InputCreateCategory>
    {
        public string Description { get; private set; } = description;
        public string Code { get; private set; } = code;
    }
}
