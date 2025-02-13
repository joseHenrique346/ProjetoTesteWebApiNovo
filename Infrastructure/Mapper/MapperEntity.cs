using System.Reflection;

namespace Infrastructure.Mapper
{
    public static class Converter
    {
        public static TOutput Convert<TOutput, TInput>(this TInput input)
            where TOutput : new()
            where TInput : class
        {
            var output = new TOutput();

            _ = (from i in typeof(TInput).GetProperties()
                 let properties = typeof(TOutput).GetProperty(i.Name)
                 where properties != null
                 let value = i.GetValue(input)
                 let _ = properties.SetProperty(output, value)
                 select true).ToArray();

            return output;
        }

        public static bool SetProperty<TOutput>(this PropertyInfo propertyInfo, TOutput output, object values)
        {
            propertyInfo.SetValue(output, values);
            return true;
        }

        public static List<TOutput> ConvertList<TOutput, TInput>(this List<TInput> listInput)
            where TOutput : new()
            where TInput : class
        {
            return (from i in listInput
                    let conv = i.Convert<TOutput, TInput>()
                    select conv).ToList();
        }
    }
}