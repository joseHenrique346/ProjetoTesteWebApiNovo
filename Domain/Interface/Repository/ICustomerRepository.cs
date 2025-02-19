using Arguments.Argument.Registration.Customer;
using Domain.DTO.Entity.Customer;
using Domain.Interface.Base;

namespace Domain.Interface.Repository
{
    public interface ICustomerRepository : IBaseRepository<CustomerDTO, InputIdentityViewCustomer> { }
}
