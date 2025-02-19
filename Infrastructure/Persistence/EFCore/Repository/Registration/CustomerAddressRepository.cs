using Arguments.Argument.Registration.CustomerAddress;
using Domain.DTO.Entity.CustomerAddress;
using Domain.Interface.Repository;
using Infrastructure.Persistence.EFCore.Context;
using Infrastructure.Persistence.EFCore.Entity.Registration;
using Infrastructure.Persistence.EFCore.Repository.Base;

namespace Infrastructure.Persistence.EFCore.Repository.Registration
{
    public class CustomerAddressRepository(AppDbContext context) : BaseRepository<CustomerAddress, CustomerAddressDTO, InputIdentityViewCustomerAddress>(context), ICustomerAddressRepository { }
}