namespace Arguments.Argument.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IdentifierAttribute : Attribute
    {
        
        public string Identifier { get; }

        public IdentifierAttribute(string identifier)
        {
            Identifier = identifier;
        }
    }
}