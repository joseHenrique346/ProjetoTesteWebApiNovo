using Arguments.Argument.Registration.Customer;
using Domain.DTO.Entity;
using Domain.Interface.Repository;
using Domain.Service.Base;

namespace Domain.Service.Registration
{
    public class CustomerService : BaseService<CustomerDTO, ICustomerRepository, InputIdentityViewCustomer, InputCreateCustomer, InputUpdateCustomer, InputIdentityUpdateCustomer, InputIdentityDeleteCustomer, OutputCustomer>
    {
        public CustomerService(ICustomerRepository repository) : base(repository) { }
    }
}