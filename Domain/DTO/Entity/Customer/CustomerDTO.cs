using Domain.DTO.Base;
using Domain.DTO.Entity.CustomerAddress;

namespace Domain.DTO.Entity.Customer
{
    public class CustomerDTO : BaseDTO
    {
        #region Properties

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Code { get; private set; }
        public string Phone { get; private set; }
        public DateOnly? BirthDate { get; private set; }
        public string Document { get; private set; }

        #endregion

        #region Constructors

        public CustomerDTO(string firstName, string lastName, string code, string phone, DateOnly? birthDate, string document)
        {
            FirstName = firstName;
            LastName = lastName;
            Code = code;
            Phone = phone;
            BirthDate = birthDate;
            Document = document;
        }

        public CustomerDTO() { }

        #endregion

        #region Internal

        public virtual List<CustomerAddressDTO> ListCustomerAddressDTO { get; set; }

        #endregion
    }
}
