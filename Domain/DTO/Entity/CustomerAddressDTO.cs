using Domain.DTO.Base;

namespace Domain.DTO.Entity
{
    public class CustomerAddressDTO : BaseDTO
    {
        #region Properties

        public long CustomerId { get; private set; }
        public string Number { get; private set; } = string.Empty;
        public string? Complement { get; private set; }
        public string? Reference { get; private set; }
        public string Neighborhood { get; private set; } = string.Empty;
        public string PostalCode { get; private set; } = string.Empty;

        #endregion

        #region Constructors

        public CustomerAddressDTO(long customerId, string number, string? complement, string? reference, string neighborhood, string postalCode)
        {
            CustomerId = customerId;
            Number = number;
            Complement = complement;
            Reference = reference;
            Neighborhood = neighborhood;
            PostalCode = postalCode;
        }

        public CustomerAddressDTO() { }

        #endregion

        #region Internal

        public CustomerDTO CustomerDTO { get; private set; }

        #endregion
    }
}