using Arguments.Argument.Base.Crud;
using Domain.DTO.Base;
using Domain.Interface.Service.Base;
using Infrastructure.Persistence.EFCore.UnitOfWork.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjetoTesteWebApiNovo.Controllers.Base
{
    public class BaseController<TService, TDTO, TOutput, TInputIdentityView, TInputCreate, TInputIdentityUpdate, TInputIdentityDelete> : Controller
        where TService : IBaseService<TDTO, TOutput, TInputIdentityView, TInputCreate, TInputIdentityUpdate, TInputIdentityDelete>
        where TDTO : BaseDTO
        where TInputIdentityView : BaseInputIdentityView<TInputIdentityView>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputIdentityUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TOutput : BaseOutput<TOutput>
    {
        #region Dependency Injection

        private readonly TService _service;
        private readonly IUnitOfWork _unitOfWork;
        public BaseController(TService service, IUnitOfWork unitOfWork)
        {
            _service = service;
            _unitOfWork = unitOfWork;
        }

        #endregion

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _unitOfWork.BeginTransaction();
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _unitOfWork.Commit();
            base.OnActionExecuted(context);
        }

        #region Get

        [HttpGet("Get")]
        public async Task<ActionResult<TOutput>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("GetListByListId")]
        public async Task<ActionResult<TOutput>> GetListByListId(List<TInputIdentityView> listInputIdentityView)
        {
            return Ok(await _service.GetListByListId(listInputIdentityView));
        }

        #endregion

        #region Create

        [HttpPost("Create/Multiple")]
        public async Task<ActionResult<TOutput>> CreateMultiple(List<TInputCreate> listInputCreate)
        {
            var result = await _service.CreateMultiple(listInputCreate);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion

        #region Update

        [HttpPut("Update/Multiple")]
        public async Task<ActionResult<TOutput>> UpdateMultiple(List<TInputIdentityUpdate> listInputIdentityUpdate)
        {
            var result = await _service.UpdateMultiple(listInputIdentityUpdate);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion

        #region Delete

        [HttpDelete("Delete/Multiple")]
        public async Task<ActionResult<TOutput>> DeleteMultiple(List<TInputIdentityDelete> listInputIdentityDelete)
        {
            var result = await _service.DeleteMultiple(listInputIdentityDelete);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion
    }
}