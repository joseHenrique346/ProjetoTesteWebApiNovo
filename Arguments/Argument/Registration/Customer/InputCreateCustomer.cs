using Arguments.Argument.Base;

namespace Arguments.Argument.Registration.Customer
{
    public class InputCreateCustomer(string firstName, string lastName, string code, string phone, DateOnly? birthDate, string document) : BaseInputCreate<InputCreateCustomer>
    {
        public string FirstName { get; private set; } = firstName;
        public string LastName { get; private set; } = lastName;
        public string Code { get; private set; } = code;
        public string Phone { get; private set; } = phone;
        public DateOnly? BirthDate { get; private set; } = birthDate;
        public string Document { get; private set; } = document;
    }
}