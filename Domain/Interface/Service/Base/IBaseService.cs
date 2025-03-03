using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Base.Crud;
using Domain.DTO.Base;
using System.Reflection;

namespace Domain.Interface.Service.Base
{
    public interface IBaseService<TDTO, TOutput, TInputIdentityView, TInputCreate, TInputIdentityUpdate, TInputIdentityDelete>
        where TDTO : BaseDTO
        where TInputIdentityView : BaseInputIdentityView<TInputIdentityView>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputIdentityUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TOutput : BaseOutput<TOutput>
    {
        Task<List<TDTO>> GetAll();

        Task<List<TDTO>> GetListByListId(List<TInputIdentityView> listInputIdentityView);

        Task<TDTO?> GetById(TInputIdentityView inputIdentityView);

        Task<BaseResult<List<TOutput>>> CreateMultiple(List<TInputCreate> listInputCreate);

        Task<BaseResult<List<TOutput>>> UpdateMultiple(List<TInputIdentityUpdate> listInputIdentityUpdate);

        Task<BaseResult<bool>> DeleteMultiple(List<TInputIdentityDelete> listInputIdentityDelete);
    }
}