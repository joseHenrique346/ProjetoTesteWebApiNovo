using Infrastructure.Persistence.EFCore.Entity.Base;

namespace Infrastructure.Persistence.EFCore.Entity.Registration
{
    public class CustomerAddress : BaseEntity
    {
        #region Properties

        public long CustomerId { get; private set; }
        public string Number { get; private set; } = string.Empty;
        public string Street { get; private set; } = string.Empty;
        public string? Complement { get; private set; }
        public string? Reference { get; private set; }
        public string Neighborhood { get; private set; } = string.Empty;
        public string PostalCode { get; private set; } = string.Empty;

        #endregion

        #region Constructors

        public CustomerAddress(long customerId, string number, string? complement, string? reference, string neighborhood, string postalCode, string street)
        {
            CustomerId = customerId;
            Number = number;
            Complement = complement;
            Reference = reference;
            Neighborhood = neighborhood;
            PostalCode = postalCode;
            Street = street;
        }

        public CustomerAddress() { }

        #endregion

        #region Internal

        public Customer Customer { get; private set; }

        #endregion
    }
}