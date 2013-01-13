using System;
using System.Collections.Generic;
using System.Text;
using LitJson;
using System.IO;

namespace Json
{
    public class JsonDeserializer
    {
        public static T deserialize<T>(Stream s)
        {
            return deserialize<T>(new JsonReader(new StreamReader(s)));
        }

        public static T deserialize<T>(string text)
        {
            return deserialize<T>(new JsonReader(text));
        }

        public static T deserialize<T>(JsonReader reader)
        {
            return JsonMapper.ToObject<T>(reader);
        }
    }
}
