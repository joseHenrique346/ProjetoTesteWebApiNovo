namespace Domain.Interface.Base
{
    public interface IBaseValidateService<TValidateDTO>
    {
        public void ValidateNullDTO(List<TValidateDTO> listValidateDTO);
    }
}
