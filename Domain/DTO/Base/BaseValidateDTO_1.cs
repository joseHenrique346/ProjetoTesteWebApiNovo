using Arguments.Argument.Base.Crud;

namespace Domain.DTO.Base
{
    public class BaseValidateDTO_1<TInputCreate, TInputUpdate, TInputIdentityDelete> : BaseValidateDTO
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
    {
        public TInputCreate? InputCreate { get; set; }
        public TInputUpdate? InputUpdate { get; set; }
        public TInputIdentityDelete? InputIdentityDelete { get; set; }
    }
}
