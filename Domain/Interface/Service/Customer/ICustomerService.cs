using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Registration.Customer;
using Domain.DTO.Entity.Customer;
using Domain.Interface.Service.Base;

namespace Domain.Interface.Service.Customer
{
    public interface ICustomerService : IBaseService<CustomerDTO, OutputCustomer, InputIdentityViewCustomer, InputCreateCustomer, InputIdentityUpdateCustomer, InputIdentityDeleteCustomer>
    {
        Task<BaseResult<List<OutputCustomer>>> CreateMultiple(List<InputCreateCustomer> listInputCreateCustomer);
        Task<BaseResult<List<OutputCustomer>>> UpdateMultiple(List<InputIdentityUpdateCustomer> listInputIdentityUpdateCustomer);
        Task<BaseResult<bool>> DeleteMultiple(List<InputIdentityDeleteCustomer> listInputIdentityDeleteCustomer);
    }
}
