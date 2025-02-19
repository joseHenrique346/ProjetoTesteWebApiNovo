using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Registration.Customer;
using Arguments.Argument.Registration.Customer;
using Domain.DTO.Entity.Customer;
using Domain.Interface.Repository;
using Domain.Service.Base;

namespace Domain.Service.Registration.CustomerService
{
    public class CustomerService : BaseService<CustomerDTO, ICustomerRepository, InputIdentityViewCustomer, InputCreateCustomer, InputUpdateCustomer, InputIdentityUpdateCustomer, InputIdentityDeleteCustomer, CustomerValidateDTO, OutputCustomer>
    {
        public CustomerService(ICustomerRepository repository) : base(repository) { }

        //public override List<OutputCustomer> CreateMultiple(List<InputCreateCustomer> listInputCreateCustomer)
        //{
        //    throw new NotImplementedException();
        //}

        public override Task<BaseResult<List<OutputCustomer>>> UpdateMultiple(List<InputIdentityUpdateCustomer> listInputIdentityUpdateCustomer)
        {
            throw new NotImplementedException();
        }

        //public override bool DeleteMultiple(List<InputIdentityDeleteCustomer> listInputIdentityDeleteCustomer)
        //{
        //    throw new NotImplementedException();
        //}
    }
}