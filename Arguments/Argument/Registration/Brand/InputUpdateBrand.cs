using Arguments.Argument.Base.Crud;

namespace Arguments.Argument.Registration.Brand
{
    public class InputUpdateBrand(string description, string code) : BaseInputUpdate<InputUpdateBrand>
    {
        public string Code { get; private set; } = code;
        public string Description { get; private set; } = description;
    }
}
