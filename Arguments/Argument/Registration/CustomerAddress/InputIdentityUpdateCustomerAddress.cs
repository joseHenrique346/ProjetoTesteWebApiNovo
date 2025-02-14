using Arguments.Argument.Base;

namespace Arguments.Argument.Registration.CustomerAddress
{
    public class InputIdentityUpdateCustomerAddress(long id, InputUpdateCustomerAddress inputUpdateCustomerAddress) : BaseInputIdentityUpdate<InputIdentityUpdateCustomerAddress>
    {
        public long Id { get; private set; } = id;
        public InputUpdateCustomerAddress InputUpdateCustomerAddress { get; private set; } = inputUpdateCustomerAddress;
    }
}