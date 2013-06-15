using LitJson;
using System.IO;

namespace Json
{
    public class JsonDeserializer
    {
        public static T Deserialize<T>(Stream s)
        {
            return Deserialize<T>(new JsonReader(new StreamReader(s)));
        }

        public static T Deserialize<T>(string text)
        {
            return Deserialize<T>(new JsonReader(text));
        }

        public static T Deserialize<T>(JsonReader reader)
        {
            return JsonMapper.ToObject<T>(reader);
        }
    }
}
