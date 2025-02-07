using Infrastructure.Persistence.EFCore.Entity.Base;

namespace Infrastructure.Persistence.EFCore.Entity.Registration
{
    public class Customer : BaseEntity
    {
        #region Properties

        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Phone { get; private set; }
        public DateOnly? BirthDate { get; private set; }
        public string Document { get; private set; }

        #endregion

        #region Constructors
        public CustomerAddress(string name, string phone, string cpf, DateOnly? birthDate, string document, string code)
        {
            Name = name;
            Phone = phone;
            CPF = cpf;
            BirthDate = birthDate;
            Document = document;
            Code = code;
        }
        public CustomerAddress() { }
        #endregion

        #region Internal

        public virtual List<CustomerAddress> ListCustomerAddress { get; set; }

        #endregion
    }
}