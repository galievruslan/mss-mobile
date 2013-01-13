using System.Text;
using LitJson;
using System.IO;
using System.Reflection;

namespace Json
{
    public class JsonSerializer
    {
        public static void Serialize(StringBuilder sb, object obj)
        {
            Serialize(new JsonWriter(sb), obj);
        }

        public static void Serialize(Stream writer, object obj)
        {
            Serialize(new JsonWriter(new StreamWriter(writer)), obj);
        }
        

        public static void Serialize(JsonWriter writer, object obj)
        {
            SerializeInternal(writer, obj);
            writer.Flush();
            writer.Close();
        }

        public static void SerializeInternal(JsonWriter writer, object obj)
        {
            // special case
            if (obj == null)
            {
                writer.Write(null);
            }
            else if (JsonTypeJuggler.IsInt(obj))
            {
                writer.Write((int)(obj));
            }
            else if (JsonTypeJuggler.IsLong(obj))
            {
                writer.Write((long)(obj));
            }
            else if (JsonTypeJuggler.IsBool(obj))
            {
                writer.Write((bool)(obj));
            }
            else if (JsonTypeJuggler.IsString(obj))
            {
                writer.Write((string)(obj));
            }
            else if (JsonTypeJuggler.IsDouble(obj))
            {
                writer.Write((double)(obj));
            }
            // array
            else if (JsonTypeJuggler.IsArray(obj))
            {
                writer.WriteArrayStart();

                if (JsonTypeJuggler.IsInt(obj.GetType().GetElementType()))
                {
                    var array = (int[])obj;

                    for (int i = 0; i < array.Length; i++)
                    {
                        SerializeInternal(writer, array[i]);
                    }
                }
                else if (JsonTypeJuggler.IsLong(obj.GetType().GetElementType()))
                {
                    var array = (long[])obj;

                    for (int i = 0; i < array.Length; i++)
                    {
                        SerializeInternal(writer, array[i]);
                    }
                }
                else if (JsonTypeJuggler.IsBool(obj.GetType().GetElementType()))
                {
                    var array = (bool[])obj;

                    for (int i = 0; i < array.Length; i++)
                    {
                        SerializeInternal(writer, array[i]);
                    }
                }
                else if (JsonTypeJuggler.IsString(obj.GetType().GetElementType()))
                {
                    var array = (string[])obj;

                    for (int i = 0; i < array.Length; i++)
                    {
                        SerializeInternal(writer, array[i]);
                    }
                }
                else if (JsonTypeJuggler.IsDouble(obj.GetType().GetElementType()))
                {
                    var array = (double[])obj;

                    for (int i = 0; i < array.Length; i++)
                    {
                        SerializeInternal(writer, array[i]);
                    }
                }
                else
                {
                    var array = (object[])obj;

                    for (int i = 0; i < array.Length; i++)
                    {
                        SerializeInternal(writer, array[i]);
                    }
                }

                writer.WriteArrayEnd();
            }
            // struct
            else
            {
                writer.WriteObjectStart();

                FieldInfo[] fields = obj.GetType().GetFields();

                for (int i = 0; i < fields.Length; i++)
                {
                    writer.WritePropertyName(fields[i].Name);
                    SerializeInternal(writer, fields[i].GetValue(obj));
                }

                writer.WriteObjectEnd();
            }
        }
    }
}
