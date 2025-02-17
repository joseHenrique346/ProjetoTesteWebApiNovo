using Arguments.Argument.Base.Crud;

namespace Arguments.Argument.Registration.Customer
{
    public class InputIdentityViewCustomer : BaseInputIdentityView<InputIdentityViewCustomer>
    {
        public long Id { get; private set; }
    }
}
