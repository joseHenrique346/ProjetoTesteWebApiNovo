using Arguments.Argument.Base.Crud;
using System.ComponentModel.DataAnnotations;

namespace Arguments.Argument.Registration.Brand
{
    public class InputCreateBrand(string description, string code) : BaseInputCreate<InputCreateBrand>
    {
        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        public string Code { get; private set; } = code;

        public string Description { get; private set; } = description;
    }
}