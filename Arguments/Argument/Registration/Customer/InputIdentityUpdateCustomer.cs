using Arguments.Argument.Base.Crud;

namespace Arguments.Argument.Registration.Customer
{
    public class InputIdentityUpdateCustomer(long id, InputUpdateCustomer inputUpdateCustomer) : BaseInputIdentityUpdate<InputIdentityUpdateCustomer>
    {
        public long Id { get; private set; } = id;
        public InputUpdateCustomer InputUpdateCustomer { get; private set; } = inputUpdateCustomer;
    }
}
