using Domain.DTO.Base;

namespace Domain.Interface.Base
{
    public interface IBaseRepository<TDTO> where TDTO : BaseDTO
    {
        Task<List<TDTO>> GetAll();
        Task<List<TDTO>> GetListByListId(List<long> id);
        Task<TDTO?> GetById(long? id);
        Task<List<TDTO>> Create(List<TDTO> listEntity);
        Task<List<TDTO>> Update(List<TDTO> listEntity);
        Task<bool> Delete(List<TDTO> listEntity);
    }
}
