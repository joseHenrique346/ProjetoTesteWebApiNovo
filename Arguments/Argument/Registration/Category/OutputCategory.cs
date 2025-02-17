using Arguments.Argument.Base.Crud;

namespace Arguments.Argument.Registration.Category
{
    public class OutputCategory : BaseOutput<OutputCategory>
    {
        #region Properties

        public long Id { get; private set; }
        public string Description { get; private set; }
        public string Code { get; private set; }

        #endregion

        #region Constructors

        public OutputCategory(string description, string code)
        {
            Description = description;
            Code = code;
        }

        public OutputCategory() { }

        #endregion
    }
}