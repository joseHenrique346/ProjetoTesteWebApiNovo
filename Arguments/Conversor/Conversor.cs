using System.Reflection;

namespace Arguments.Conversor
{
    public static class Conversor
    {
        public static TOutput GenericConvert<TOutput, TInput>(this TInput input)
            where TInput : class
            where TOutput : new()
        {
            TOutput output = new TOutput();

            (from i in input.GetType().GetProperties()
             let properties = output.GetType().GetProperty(i.Name)
             where properties != null
             select properties.setValue(output, i.GetValue(input))).ToList();

            return output;
        }

        public static TOutput setValue<TOutput>(this PropertyInfo propertyInfo, TOutput output, object value)
        {
            propertyInfo.SetValue(output, value);
            return output;
        }

        public static List<TOutput> GenericConvertList<TOutput, TInput>(this List<TInput> listInput)
            where TInput : class
            where TOutput : new()
        {
            return (from i in listInput
                    select i.GenericConvert<TOutput, TInput>()).ToList();
        }
    }
}