namespace Arguments.Argument.Registration.CustomerAddress
{
    public class InputIdentityUpdateCustomerAddress(long id, InputUpdateCustomerAddress inputUpdateCustomerAddress)
    {
        public long Id { get; private set; } = id;
        public InputUpdateCustomerAddress InputUpdateCustomerAddress { get; private set; } = inputUpdateCustomerAddress;
    }
}