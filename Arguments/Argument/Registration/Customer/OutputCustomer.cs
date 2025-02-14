using Arguments.Argument.Base;

namespace Arguments.Argument.Registration.Customer
{
    public class OutputCustomer : BaseOutput<OutputCustomer>
    {
        #region Properties

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Phone { get; private set; }
        public string Document { get; private set; }

        #endregion

        #region Constructors

        public OutputCustomer(string firstName, string lastName, string phone, string document)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Document = document;
        }

        public OutputCustomer() { }

        #endregion
    }
}
