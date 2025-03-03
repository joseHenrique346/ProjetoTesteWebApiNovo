using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Base.Crud;
using Domain.DTO.Base;
using Domain.Interface.Base;
using System.Reflection;
namespace Domain.Service.Base
{
    public class BaseService<TDTO, TRepository, TInputIdentityView, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TValidateDTO, TOutput> : BaseValidate<TValidateDTO>
        where TDTO : BaseDTO
        where TRepository : IBaseRepository<TDTO, TInputIdentityView>
        where TInputIdentityView : BaseInputIdentityView<TInputIdentityView>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputIdentityUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TValidateDTO : BaseValidateDTO
        where TOutput : BaseOutput<TOutput>, new()
    {
        private readonly TRepository _repository;

        public BaseService(TRepository repository)
        {
            _repository = repository;
        }

        public virtual async Task<List<TDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        public virtual async Task<List<TDTO>> GetListByListId(List<long> listInputIdentityView)
        {
            return await _repository.GetListByListId(listInputIdentityView);
        }

        public virtual async Task<TDTO?> GetById(TInputIdentityView inputIdentityView)
        {
            return await _repository.GetById(inputIdentityView);
        }

        public virtual async Task<BaseResult<List<TOutput>>> CreateMultiple(List<TInputCreate> listInputCreate)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<BaseResult<List<TOutput>>> UpdateMultiple(List<TInputIdentityUpdate> listInputIdentityUpdate)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<BaseResult<bool>> DeleteMultiple(List<TInputIdentityDelete> listInputIdentityDelete)
        {
            throw new NotImplementedException();
        }
    }
}