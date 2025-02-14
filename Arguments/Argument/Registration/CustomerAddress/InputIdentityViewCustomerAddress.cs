using Arguments.Argument.Base;

namespace Arguments.Argument.Registration.CustomerAddress
{
    public class InputIdentityViewCustomerAddress(long id) : BaseInputIdentityView<InputIdentityViewCustomerAddress>
    {
        public long Id { get; private set; } = id;
    }
}
