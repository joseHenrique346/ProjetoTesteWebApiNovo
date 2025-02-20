using Arguments.Argument.Base.Crud;
using System.ComponentModel.DataAnnotations;

namespace Arguments.Argument.Registration.Category
{
    public class InputCreateCategory(string description, string code) : BaseInputCreate<InputCreateCategory>
    {
        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        public string Code { get; private set; } = code;

        public string Description { get; private set; } = description;
    }
}
