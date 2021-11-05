using Margarida.Util.String;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Margarida.Util.Linq
{
    public static class LinqExt
    {
        public static string Serialize<T>(this T input) => JsonConvert.SerializeObject(input);

        public static T Deserialize<T>(this string input) where T : new() => JsonConvert.DeserializeObject<T>(input) ?? new T();

        public static T Clone<T>(this T obj) where T : new() => obj.Serialize().Deserialize<T>();

        public static TSource Inner<TSource>(this TSource input, Action<TSource> action)
        {
            action(input);
            return input;
        }
        
        public static T RunMethod<T>(Func<object, T> method) where T : new() => method(method.Target ?? new T());

        public static T RunMethod<T>(Func<object, T> method, Func<object, T> excepetionTreatment) where T : new()
        {
            try { return method(method.Target ?? new T()); } catch { return excepetionTreatment(excepetionTreatment.Target ?? new T()); }
        }

        public static T Copy<T>(this object source) where T : new()
        {
            return TryConvert(source);

            T TryConvert(object source)
            {
                try
                {
                    return source.Serialize().Deserialize<T>();
                }
                catch (Exception ex)
                {
                    var graph = JObject.Parse(source.Serialize());
                    ExtractMembersFromException(ex, out var value, out var propertiesLevel);
                    TreatedMembers(graph, propertiesLevel, level: 0, value);
                    var copy = TryConvert(graph);
                    return copy;
                }
            }

            void TreatedMembers(JObject? graph, string[] propertiesLevel, int level, string value)
            {
                if (graph?.Property(propertiesLevel[level])?.Value.ToString() == value)
                {
                    graph.Property(propertiesLevel[level])?.Remove();
                }
                else
                {
                    TreatedMembers(graph?[propertiesLevel[level]] as JObject, propertiesLevel, ++level, value);
                }
            }

            (string, string[]) ExtractMembersFromException(Exception ex, out string value, out string[] propertiesLevel) => (value = ex.Message.Between(": ", ". Path"), propertiesLevel = ex.Message.Between(" Path '", "'").Split('.'));

        }
    }
}
