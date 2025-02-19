using Arguments.Argument.Registration.Category;
using Domain.DTO.Base;

namespace Domain.DTO.Entity.Category
{
    public class CategoryValidateDTO : BaseValidateDTO
    {
        public InputCreateCategory InputCreateCategory { get; set; }
        public InputUpdateCategory InputUpdateCategory { get; set; }
        public InputIdentityUpdateCategory InputIdentityUpdateCategory { get; set; }
        public InputIdentityDeleteCategory InputIdentityDeleteCategory { get; set; }
    }
}
