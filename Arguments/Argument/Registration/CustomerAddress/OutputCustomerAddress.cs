using Arguments.Argument.Base.Crud;

namespace Arguments.Argument.Registration.CustomerAddress
{
    public class OutputCustomerAddress : BaseOutput<OutputCustomerAddress>
    {
        #region Properties

        public long Id { get; private set; }
        public string Number { get; private set; }
        public string Street { get; private set; }
        public string Neighborhood { get; private set; }
        public string PostalCode { get; private set; }

        #endregion

        #region Constructors

        public OutputCustomerAddress(string number, string street, string neighborhood, string postalCode)
        {
            Number = number;
            Street = street;
            Neighborhood = neighborhood;
            PostalCode = postalCode;
        }

        public OutputCustomerAddress() { }

        #endregion
    }
}