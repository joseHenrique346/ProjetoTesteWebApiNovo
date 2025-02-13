namespace Arguments.Argument.Registration.Customer
{
    public class InputIdentityUpdateCustomer(long id, InputUpdateCustomer inputUpdateCustomer)
    {
        public long Id { get; private set; } = id;
        public InputUpdateCustomer InputUpdateCustomer { get; private set; } = inputUpdateCustomer;
    }
}
