using Arguments.Argument.Base.Crud;
using Arguments.Argument.Interface;

namespace Arguments.Argument.Registration.Customer
{
    public class InputIdentityViewCustomer : BaseInputIdentityView<InputIdentityViewCustomer>, IBaseIdentityView
    {
        public long Id { get; private set; }
    }
}
