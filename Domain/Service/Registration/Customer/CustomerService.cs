using Arguments.Argument.Registration.Customer;
using Domain.DTO.Entity;
using Domain.Interface.Repository;

namespace Domain.Service.Registration.CustomerService
{
    public class CustomerService : BaseService<CustomerDTO, ICustomerRepository, InputIdentityViewCustomer, InputCreateCustomer, InputUpdateCustomer, InputIdentityUpdateCustomer, InputIdentityDeleteCustomer, OutputCustomer>
    {
        public CustomerService(ICustomerRepository repository) : base(repository) { }
    }
}