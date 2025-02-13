using Domain.DTO.Entity;
using Domain.Interface.Repository;
using Infrastructure.Persistence.EFCore.Context;
using Infrastructure.Persistence.EFCore.Entity.Registration;
using Infrastructure.Persistence.EFCore.Repository.Base;

namespace Infrastructure.Persistence.EFCore.Repository.Registration
{
    public class CustomerRepository(AppDbContext context, IMapper mapper) : BaseRepository<Customer, CustomerDTO>(context, mapper), ICustomerRepository { }
}