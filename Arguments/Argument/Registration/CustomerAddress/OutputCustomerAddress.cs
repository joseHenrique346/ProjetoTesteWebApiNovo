using Arguments.Argument.Base.Crud;

namespace Arguments.Argument.Registration.CustomerAddress
{
    public class OutputCustomerAddress : BaseOutput<OutputCustomerAddress>
    {
        #region Properties

        public long Id { get; private set; }
        public long CustomerId { get; private set; }
        public string Number { get; private set; }
        public string Street { get; private set; }
        public string? Complement { get; private set; }
        public string? Reference { get; private set; }
        public string Neighborhood { get; private set; }
        public string PostalCode { get; private set; }

        #endregion

        #region Constructors

        public OutputCustomerAddress(long id, long customerId, string number, string? complement, string? reference, string neighborhood, string postalCode, string street)
        {
            Id = id;
            CustomerId = customerId;
            Number = number;
            Complement = complement;
            Reference = reference;
            Neighborhood = neighborhood;
            PostalCode = postalCode;
            Street = street;
        }

        public OutputCustomerAddress() { }

        #endregion
    }
}