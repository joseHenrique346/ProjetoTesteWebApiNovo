using Arguments.Argument.Base.Crud;
using Arguments.Argument.Interface;

namespace Arguments.Argument.Registration.CustomerAddress
{
    public class InputIdentityViewCustomerAddress(long id) : BaseInputIdentityView<InputIdentityViewCustomerAddress>, IBaseIdentityView
    {
        public long Id { get; private set; } = id;
    }
}
