﻿using Arguments.Argument.Base.Crud;

namespace Arguments.Argument.Registration.CustomerAddress
{
    public class InputUpdateCustomerAddress(long customerId, string number, string? complement, string? reference, string neighborhood, string postalCode) : BaseInputUpdate<InputUpdateCustomerAddress>
    {
        public long CustomerId { get; private set; } = customerId;
        public string Number { get; private set; } = number;
        public string? Complement { get; private set; } = complement;
        public string? Reference { get; private set; } = reference;
        public string Neighborhood { get; private set; } = neighborhood;
        public string PostalCode { get; private set; } = postalCode;
    }
}
