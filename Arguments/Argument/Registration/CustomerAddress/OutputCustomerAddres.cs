using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Arguments.Argument.Registration.CustomerAddress
{
    public class OutputCustomerAddres(string number, string street, string neighborhood, string postalCode)
    {
        public string Number { get; private set; } = number;
        public string Street { get; private set; } = street;
        public string Neighborhood { get; private set; } = neighborhood;
        public string PostalCode { get; private set; } = postalCode;
    }
}