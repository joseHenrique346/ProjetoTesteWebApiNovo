using Arguments.Argument.Base.Crud;

namespace Arguments.Argument.Registration.CustomerAddress
{
    public class InputIdentityDeleteCustomerAddress : BaseInputIdentityDelete<InputIdentityDeleteCustomerAddress>
    {
        public long Id { get; private set; }
    }
}
