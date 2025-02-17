using Arguments.Argument.Base.Crud;

namespace Arguments.Argument.Registration.CustomerAddress
{
    public class OutputCustomerAddres : BaseOutput<OutputCustomerAddres>
    {
        #region Properties

        public long Id { get; private set; }
        public string Number { get; private set; }
        public string Street { get; private set; }
        public string Neighborhood { get; private set; }
        public string PostalCode { get; private set; }

        #endregion

        #region Constructors

        public OutputCustomerAddres(string number, string street, string neighborhood, string postalCode)
        {
            Number = number;
            Street = street;
            Neighborhood = neighborhood;
            PostalCode = postalCode;
        }

        public OutputCustomerAddres() { }

        #endregion
    }
}