using Domain.DTO.Base;
using Domain.Interface.Base;

namespace Domain.Service.Base
{
    public class BaseValidateService<TValidateDTO> : BaseValidate<TValidateDTO>, IBaseValidateService<TValidateDTO>
        where TValidateDTO : BaseValidateDTO
    {
        public void ValidateNullDTO(List<TValidateDTO> listValidateDTO)
        {
            (from i in RemoveIgnore(listValidateDTO)
             where listValidateDTO == null
             let setIgnore = i.SetIgnore()
             select Invalid(listValidateDTO.IndexOf(i))).ToList();
        }
    }
}