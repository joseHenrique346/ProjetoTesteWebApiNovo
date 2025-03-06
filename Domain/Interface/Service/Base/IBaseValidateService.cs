using Domain.DTO.Base;

namespace Domain.Interface.Service.Base
{
    public interface IBaseValidateService<TValidateDTO>
        where TValidateDTO : BaseValidateDTO
    {
        public void ValidateNullDTO(List<TValidateDTO> listValidateDTO);
    }
}