using Arguments.Argument.Registration.CustomerAddress;
using Domain.DTO.Entity.CustomerAddress;
using Domain.Interface.Service.CustomerAddress;
using Infrastructure.Persistence.EFCore.UnitOfWork.Interface;
using Microsoft.AspNetCore.Mvc;
using ProjetoTesteWebApiNovo.Controllers.Base;

namespace ProjetoTesteWebApiNovo.Controllers.Registration
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerAddressController : BaseController<ICustomerAddressService, CustomerAddressDTO, OutputCustomerAddress, InputIdentityViewCustomerAddress, InputCreateCustomerAddress, InputIdentityUpdateCustomerAddress, InputIdentityDeleteCustomerAddress>
    {
        public CustomerAddressController(ICustomerAddressService service, IUnitOfWork unitOfWork) : base(service, unitOfWork) { }
    }
}
