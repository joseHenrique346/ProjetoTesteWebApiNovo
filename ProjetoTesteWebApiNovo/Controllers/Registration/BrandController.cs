using Arguments.Argument.Registration.Brand;
using Domain.DTO.Entity.Brand;
using Domain.Interface.Service.Brand;
using Infrastructure.Persistence.EFCore.UnitOfWork.Interface;
using Microsoft.AspNetCore.Mvc;
using ProjetoTesteWebApiNovo.Controllers.Base;

namespace ProjetoTesteWebApiNovo.Controllers.Registration
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : BaseController<IBrandService, BrandDTO, OutputBrand, InputIdentityViewBrand, InputCreateBrand, InputIdentityUpdateBrand, InputIdentityDeleteBrand>
    {
        public BrandController(IBrandService service, IUnitOfWork unitOfWork) : base(service, unitOfWork) { }
    }
}