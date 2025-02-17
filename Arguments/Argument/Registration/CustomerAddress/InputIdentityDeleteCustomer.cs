using Arguments.Argument.Base.Crud;

namespace Arguments.Argument.Registration.CustomerAddress
{
    public class InputIdentityDeleteCustomer : BaseInputIdentityDelete<InputIdentityDeleteCustomer>
    {
        public long Id { get; private set; }
    }
}
