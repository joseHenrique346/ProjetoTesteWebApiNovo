using Arguments.Argument.Registration.Product;
using Domain.DTO.Entity.Product;
using Domain.Interface.Service.Product;
using Infrastructure.Persistence.EFCore.UnitOfWork.Interface;
using Microsoft.AspNetCore.Mvc;
using ProjetoTesteWebApiNovo.Controllers.Base;

namespace ProjetoTesteWebApiNovo.Controllers.Registration
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseController<IProductService, ProductDTO, OutputProduct, InputIdentityViewProduct, InputCreateProduct, InputIdentityUpdateProduct, InputIdentityDeleteProduct>
    {
        public ProductController(IProductService service, IUnitOfWork unitOfWork) : base(service, unitOfWork) { }
    }
}
