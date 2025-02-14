using Arguments.Argument.Base;
using Arguments.Argument.Conversor;
using Domain.DTO.Base;
using Domain.Interface.Base;
namespace Domain.Service.Base
{
    public class BaseService<TDTO, TRepository, TInputIdentityView, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput>
        where TDTO : BaseDTO
        where TRepository : IBaseRepository<TDTO, TInputIdentityView>
        where TInputIdentityView : BaseInputIdentityView<TInputIdentityView>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputIdentityUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TOutput : BaseOutput<TOutput>, new()
    {
        private readonly TRepository _repository;

        public BaseService(TRepository repository)
        {
            _repository = repository;
        }

        public virtual async Task<List<TOutput>> GetAll()
        {
            var getAll = await _repository.GetAll();
            return getAll.GenericConvertList<TOutput, TDTO>();
        }

        public virtual async Task<List<TOutput>> GetListByListId(List<TInputIdentityView> listInputIdentityView)
        {
            var getListById = await _repository.GetListByListId(listInputIdentityView);
            return getListById.GenericConvertList<TOutput, TDTO>();
        }

        public virtual async Task<TOutput> GetById(TInputIdentityView inputIdentityView)
        {
            var getById = await _repository.GetById(inputIdentityView);
            return getById.GenericConvert<TOutput, TDTO>();
        }

        public virtual List<TOutput> CreateMultiple(List<TInputCreate> listInputCreate)
        {
            throw new NotImplementedException();
        }

        public virtual List<TOutput> UpdateMultiple(List<TInputIdentityUpdate> listInputIdentityUpdate)
        {
            throw new NotImplementedException();
        }

        public virtual bool DeleteMultiple(List<TInputIdentityDelete> listInputIdentityDelete)
        {
            throw new NotImplementedException();
        }
    }
}
