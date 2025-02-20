using Infrastructure.Persistence.EFCore.Entity.Base;

namespace Infrastructure.Persistence.EFCore.Entity.Registration
{
    public class Customer : BaseEntity
    {
        #region Properties

        public string Code { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Phone { get; private set; }
        public DateOnly? BirthDate { get; private set; }
        public string Document { get; private set; }

        #endregion

        #region Constructors

        public Customer(string firstName, string lastName, string code, string phone, DateOnly? birthDate, string document)
        {
            FirstName = firstName;
            LastName = lastName;
            Code = code;
            Phone = phone;
            BirthDate = birthDate;
            Document = document;
        }

        public Customer() { }

        #endregion

        #region Internal

        public virtual List<CustomerAddress> ListCustomerAddress { get; set; }

        #endregion
    }
}