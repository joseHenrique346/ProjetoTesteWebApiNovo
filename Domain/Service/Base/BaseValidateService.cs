using Domain.DTO.Base;

namespace Domain.Service.Base
{
    public class BaseValidateService<TValidateDTO> : BaseValidate<TValidateDTO> where TValidateDTO : BaseValidateDTO { }
}
