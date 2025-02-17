using Arguments.Argument.Base.Crud;
using Domain.DTO.Base;

namespace Domain.Interface.Base
{
    public interface IBaseRepository<TDTO, TInputIdentityView>
        where TDTO : BaseDTO
        where TInputIdentityView : BaseInputIdentityView<TInputIdentityView>
    {
        Task<List<TDTO>> GetAll();
        Task<List<TDTO>> GetListByListId(List<TInputIdentityView> listId);
        Task<TDTO?> GetById(TInputIdentityView? id);
        Task<List<TDTO>> Create(List<TDTO> listDTO);
        Task<List<TDTO>> Update(List<TDTO> listDTO);
        Task<bool> Delete(List<TDTO> listDTO);
    }
}