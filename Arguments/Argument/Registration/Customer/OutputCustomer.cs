namespace Arguments.Argument.Registration.Customer
{
    public record OutputCustomer(string FirstName, string LastName, string Phone, string Document)
    {
        public string FirstName { get; private set; } = FirstName;
        public string LastName { get; private set; } = LastName;
        public string Phone { get; private set; } = Phone;
        public string Document { get; private set; } = Document;
    }
}
