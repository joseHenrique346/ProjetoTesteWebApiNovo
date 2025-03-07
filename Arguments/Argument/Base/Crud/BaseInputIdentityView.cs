using Arguments.Argument.Interface;
using System.Text.Json.Serialization;

namespace Arguments.Argument.Base.Crud
{
    public class BaseInputIdentityView<TInputIdentityView> where TInputIdentityView : BaseInputIdentityView<TInputIdentityView> { }

    [method: JsonConstructor]
    public class BaseIdentityView_0(long id) : BaseInputIdentityView<BaseIdentityView_0>, IBaseIdentityView
    {
        public long Id { get; } = id;
    }
}
