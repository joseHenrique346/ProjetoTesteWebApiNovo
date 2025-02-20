using Arguments.Argument.Base.Crud;
using System.ComponentModel.DataAnnotations;

namespace Arguments.Argument.Registration.CustomerAddress
{
    public class InputCreateCustomerAddress(long customerId, string street, string number, string? complement, string? reference, string neighborhood, string postalCode) : BaseInputCreate<InputCreateCustomerAddress>
    {
        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        public string PostalCode { get; private set; } = postalCode;

        public long CustomerId { get; private set; } = customerId;
        public string Street { get; private set; } = street;
        public string Number { get; private set; } = number;
        public string? Complement { get; private set; } = complement;
        public string? Reference { get; private set; } = reference;
        public string Neighborhood { get; private set; } = neighborhood;
    }
}