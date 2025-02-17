using Arguments.Argument.Base.Crud;

namespace Arguments.Argument.Registration.Product
{
    public class InputIdentityDeleteCustomer : BaseInputIdentityDelete<InputIdentityDeleteCustomer>
    {
        public long Id { get; private set; }
    }
}