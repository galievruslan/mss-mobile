using System;
using System.Collections.Generic;
using System.Text;
using LitJson;
using System.IO;
using System.Reflection;

namespace Json
{
    public class JsonSerializer
    {
        public static void serialize(StringBuilder sb, object obj)
        {
            serialize(new JsonWriter(sb), obj);
        }

        public static void serialize(Stream writer, object obj)
        {
            serialize(new JsonWriter(new StreamWriter(writer)), obj);
        }
        

        public static void serialize(JsonWriter writer, object obj)
        {
            serializeInternal(writer, obj);
            writer.flush();
            writer.close();
        }

        public static void serializeInternal(JsonWriter writer, object obj)
        {
            // special case
            if (obj == null)
            {
                writer.Write(null);
            }
            else if (JsonTypeJuggler.isInt(obj))
            {
                writer.Write((int)(obj));
            }
            else if (JsonTypeJuggler.isLong(obj))
            {
                writer.Write((long)(obj));
            }
            else if (JsonTypeJuggler.isBool(obj))
            {
                writer.Write((bool)(obj));
            }
            else if (JsonTypeJuggler.isString(obj))
            {
                writer.Write((string)(obj));
            }
            else if (JsonTypeJuggler.isDouble(obj))
            {
                writer.Write((double)(obj));
            }
            // array
            else if (JsonTypeJuggler.isArray(obj))
            {
                writer.WriteArrayStart();

                if (JsonTypeJuggler.isInt(obj.GetType().GetElementType()))
                {
                    int[] array = (int[])obj;

                    for (int i = 0; i < array.Length; i++)
                    {
                        serializeInternal(writer, array[i]);
                    }
                }
                else if (JsonTypeJuggler.isLong(obj.GetType().GetElementType()))
                {
                    long[] array = (long[])obj;

                    for (int i = 0; i < array.Length; i++)
                    {
                        serializeInternal(writer, array[i]);
                    }
                }
                else if (JsonTypeJuggler.isBool(obj.GetType().GetElementType()))
                {
                    bool[] array = (bool[])obj;

                    for (int i = 0; i < array.Length; i++)
                    {
                        serializeInternal(writer, array[i]);
                    }
                }
                else if (JsonTypeJuggler.isString(obj.GetType().GetElementType()))
                {
                    string[] array = (string[])obj;

                    for (int i = 0; i < array.Length; i++)
                    {
                        serializeInternal(writer, array[i]);
                    }
                }
                else if (JsonTypeJuggler.isDouble(obj.GetType().GetElementType()))
                {
                    double[] array = (double[])obj;

                    for (int i = 0; i < array.Length; i++)
                    {
                        serializeInternal(writer, array[i]);
                    }
                }
                else
                {
                    object[] array = (object[])obj;

                    for (int i = 0; i < array.Length; i++)
                    {
                        serializeInternal(writer, array[i]);
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
                    serializeInternal(writer, fields[i].GetValue(obj));
                }

                writer.WriteObjectEnd();
            }
        }
    }
}
