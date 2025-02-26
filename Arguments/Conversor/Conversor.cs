using System.Collections;
using System.Reflection;

namespace Arguments.Conversor
{
    //public static class Conversor
    //{
    //    public static TOutput GenericConvert<TOutput, TInput>(this TInput input)
    //        where TInput : class
    //        where TOutput : new()
    //    {
    //        TOutput output = new TOutput();

    //        var conver = (from i in input.GetType().GetProperties()
    //                      let properties = output.GetType().GetProperty(i.Name)
    //                      where properties != null
    //                      select properties.setValue(output, i.GetValue(input))).ToList();

    //        return output;
    //    }

    //    public static TOutput setValue<TOutput>(this PropertyInfo propertyInfo, TOutput output, object value)
    //    {
    //        propertyInfo.SetValue(output, value);
    //        return output;
    //    }

    //    public static List<TOutput> GenericConvertList<TOutput, TInput>(this List<TInput> listInput)
    //        where TInput : class
    //        where TOutput : new()
    //    {
    //        return (from i in listInput
    //                select i.GenericConvert<TOutput, TInput>()).ToList();
    //    }
    //}

    public static class Conversor 
    {
        public static TOutput GenericConvert<TOutput, TInput>(this TInput input)
            where TOutput : new()
            where TInput : class
        {
            if (input == null) return default;

            TOutput output = new TOutput();

            var conver = (from i in input.GetType().GetProperties()
                          let properties = output.GetType().GetProperty(i.Name)
                          where properties != null
                          let convert = properties.TryConvert(output, i.GetValue(input))
                          select convert).ToList();

            return output;
        }

        public static TOutput TryConvert<TOutput>(this PropertyInfo properties, TOutput output, object value)
            where TOutput : new()
        {
            var tipo = properties.PropertyType;
            if (tipo.IsGenericType && tipo.GetGenericTypeDefinition() == typeof(List<>))
            {
                var verificationType = tipo.GenericTypeArguments[0];
                if (verificationType.IsClass && !verificationType.IsPrimitive && verificationType != typeof(string))
                {
                    var list = value as IEnumerable;
                    if (list != null)
                    {
                        var outputList = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(verificationType));
                        var conversorMethod = typeof(Conversor).GetMethod("Converter").MakeGenericMethod(verificationType, value.GetType().GenericTypeArguments[0]);
                        foreach (var i in list)
                        {
                            var conversor = conversorMethod.Invoke(null, new[] { i });
                            outputList.Add(conversor);
                        }
                        properties.SetValue(output, outputList);
                        return output;
                    }
                }
                properties.SetValue(output, value);
                return output;
            }
            else if (tipo.IsClass && !tipo.IsPrimitive && tipo != typeof(string))
            {
                var conversorMethod = typeof(Conversor).GetMethod("Converter").MakeGenericMethod(tipo, value.GetType());
                var conversor = conversorMethod.Invoke(null, new[] { value });
                properties.SetValue(output, conversor);
                return output;
            }
            properties.SetValue(output, value);
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