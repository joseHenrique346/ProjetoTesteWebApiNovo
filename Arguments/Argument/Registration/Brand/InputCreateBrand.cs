using Arguments.Argument.Base;

namespace Arguments.Argument.Registration.Brand
{
    public class InputCreateBrand(string description, string code) : BaseInputCreate<InputCreateBrand>
    {
        public string Description { get; private set; } = description;
        public string Code { get; private set; } = code;
    }
}