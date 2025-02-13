namespace Arguments.Argument.Registration.Brand
{
    public class OutputBrand(string description, string code)
    {
        public string Description { get; private set; } = description;
        public string Code { get; private set; } = code;
    }
}
