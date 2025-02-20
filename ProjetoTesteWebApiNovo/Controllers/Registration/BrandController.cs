using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Registration.Brand;
using Domain.Interface.Service.Brand;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoTesteWebApiNovo.Controllers.Registration
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("create-multiple")]
        public async Task<ActionResult<BaseResult<List<OutputBrand>>>> CreateMultiple([FromBody] List<InputCreateBrand> listInputCreateBrand)
        {
            if (listInputCreateBrand == null || !listInputCreateBrand.Any())
            {
                return BadRequest("A lista de marcas não pode estar vazia.");
            }

            var result = await _brandService.CreateMultiple(listInputCreateBrand);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}