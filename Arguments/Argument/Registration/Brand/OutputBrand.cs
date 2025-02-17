using Arguments.Argument.Base.Crud;

namespace Arguments.Argument.Registration.Brand
{
    public class OutputBrand : BaseOutput<OutputBrand>
    {
        #region Properties

        public long Id { get; private set; }
        public string Description { get; private set; }
        public string Code { get; private set; }

        #endregion

        #region Constructors

        public OutputBrand(string description, string code)
        {
            Description = description;
            Code = code;
        }

        public OutputBrand() { }

        #endregion
    }
}
