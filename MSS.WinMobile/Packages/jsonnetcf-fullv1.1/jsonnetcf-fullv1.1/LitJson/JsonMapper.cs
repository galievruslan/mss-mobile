#region Header
/**
 * JsonMapper.cs
 *   JSON to .Net object and object to JSON conversions.
 *
 * The authors disclaim copyright to this source code. For more details, see
 * the COPYING file included with this distribution.
 **/
#endregion


using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;


namespace LitJson
{
    internal struct PropertyMetadata
    {
        public MemberInfo Info;
        public bool       IsField;
        public Type       Type;
    }
    
    internal struct ArrayMetadata
    {
        private Type _elementType;


        public Type ElementType {
            get
            {
                return _elementType ?? typeof (JsonData);
            }

            set { _elementType = value; }
        }

        public bool IsArray { get; set; }

        public bool IsList { get; set; }
    }

    internal struct ObjectMetadata
    {
        private Type _elementType;


        public Type ElementType {
            get
            {
                return _elementType ?? typeof (JsonData);
            }

            set { _elementType = value; }
        }

        public bool IsDictionary { get; set; }

        public IDictionary<string, PropertyMetadata> Properties { get; set; }
    }

    internal delegate void ExporterFunc    (object obj, JsonWriter writer);
    public   delegate void ExporterFunc<T> (T obj, JsonWriter writer);

    internal delegate object ImporterFunc                (object input);
    public   delegate TValue ImporterFunc<TJson, TValue> (TJson input);

    public delegate IJsonWrapper WrapperFactory ();

    public class JsonMapper
    {
        #region Fields
        private static readonly int MaxNestingDepth;

        private static readonly IFormatProvider DatetimeFormat;

        private static readonly IDictionary<Type, ExporterFunc> BaseExportersTable;
        private static readonly IDictionary<Type, ExporterFunc> CustomExportersTable;

        private static readonly IDictionary<Type,
                IDictionary<Type, ImporterFunc>> BaseImportersTable;
        private static readonly IDictionary<Type,
                IDictionary<Type, ImporterFunc>> CustomImportersTable;

        private static readonly IDictionary<Type, ArrayMetadata> ArrayMetadata;
        private static readonly object ArrayMetadataLock = new Object ();

        private static readonly IDictionary<Type,
                IDictionary<Type, MethodInfo>> ConvOps;
        private static readonly object ConvOpsLock = new Object ();

        private static readonly IDictionary<Type, ObjectMetadata> ObjectMetadata;
        private static readonly object ObjectMetadataLock = new Object ();

        private static readonly IDictionary<Type,
                IList<PropertyMetadata>> TypeProperties;
        private static readonly object TypePropertiesLock = new Object ();

        private static readonly JsonWriter      StaticWriter;
        private static readonly object StaticWriterLock = new Object ();
        #endregion

        #region Constructors
        static JsonMapper ()
        {
            MaxNestingDepth = 100;

            ArrayMetadata = new Dictionary<Type, ArrayMetadata> ();
            ConvOps = new Dictionary<Type, IDictionary<Type, MethodInfo>> ();
            ObjectMetadata = new Dictionary<Type, ObjectMetadata> ();
            TypeProperties = new Dictionary<Type,
                            IList<PropertyMetadata>> ();

            StaticWriter = new JsonWriter ();

            DatetimeFormat = DateTimeFormatInfo.InvariantInfo;

            BaseExportersTable   = new Dictionary<Type, ExporterFunc> ();
            CustomExportersTable = new Dictionary<Type, ExporterFunc> ();

            BaseImportersTable = new Dictionary<Type,
                                 IDictionary<Type, ImporterFunc>> ();
            CustomImportersTable = new Dictionary<Type,
                                   IDictionary<Type, ImporterFunc>> ();

            RegisterBaseExporters ();
            RegisterBaseImporters ();
        }
        #endregion


        #region Private Methods
        private static void AddArrayMetadata (Type type)
        {
            if (ArrayMetadata.ContainsKey (type))
                return;

            var data = new ArrayMetadata {IsArray = type.IsArray};

            if (GetInterface(type,"System.Collections.IList") != null)
                data.IsList = true;

            foreach (PropertyInfo pInfo in type.GetProperties ()) {
                if (pInfo.Name != "Item")
                    continue;

                ParameterInfo[] parameters = pInfo.GetIndexParameters ();

                if (parameters.Length != 1)
                    continue;

                if (parameters[0].ParameterType == typeof (int))
                    data.ElementType = pInfo.PropertyType;
            }

            lock (ArrayMetadataLock) {
                try {
                    ArrayMetadata.Add (type, data);
                } catch (ArgumentException) {
                }
            }
        }

        private static Type GetInterface(Type type, string name)
        {
            Type[] subType = type.GetInterfaces();

            for (int i = 0; i < subType.Length; i++)
            {
                if (String.Compare(subType[i].Name, name, StringComparison.Ordinal) == 0)
                {
                    return subType[i];
                }
            }

            return null;
        }

        private static void AddObjectMetadata(Type type)
        {
            if (ObjectMetadata.ContainsKey (type))
                return;

            var data = new ObjectMetadata ();

            if (GetInterface (type,"System.Collections.IDictionary") != null)
                data.IsDictionary = true;

            data.Properties = new Dictionary<string, PropertyMetadata> ();

            foreach (PropertyInfo pInfo in type.GetProperties ()) {
                if (pInfo.Name == "Item") {
                    ParameterInfo[] parameters = pInfo.GetIndexParameters ();

                    if (parameters.Length != 1)
                        continue;

                    if (parameters[0].ParameterType == typeof (string))
                        data.ElementType = pInfo.PropertyType;

                    continue;
                }

                var pData = new PropertyMetadata {Info = pInfo, Type = pInfo.PropertyType};

                data.Properties.Add (pInfo.Name, pData);
            }

            foreach (FieldInfo fInfo in type.GetFields ()) {
                var pData = new PropertyMetadata {Info = fInfo, IsField = true, Type = fInfo.FieldType};

                data.Properties.Add (fInfo.Name, pData);
            }

            lock (ObjectMetadataLock) {
                try {
                    ObjectMetadata.Add (type, data);
                } catch (ArgumentException) {
                }
            }
        }

        private static void AddTypeProperties (Type type)
        {
            if (TypeProperties.ContainsKey (type))
                return;

            IList<PropertyMetadata> props = new List<PropertyMetadata> ();

            foreach (PropertyInfo pInfo in type.GetProperties ()) {
                if (pInfo.Name == "Item")
                    continue;

                var pData = new PropertyMetadata {Info = pInfo, IsField = false};
                props.Add (pData);
            }

            foreach (FieldInfo fInfo in type.GetFields ()) {
                var pData = new PropertyMetadata {Info = fInfo, IsField = true};

                props.Add (pData);
            }

            lock (TypePropertiesLock) {
                try {
                    TypeProperties.Add (type, props);
                } catch (ArgumentException) {
                }
            }
        }

        private static MethodInfo GetConvOp (Type t1, Type t2)
        {
            lock (ConvOpsLock) {
                if (! ConvOps.ContainsKey (t1))
                    ConvOps.Add (t1, new Dictionary<Type, MethodInfo> ());
            }

            if (ConvOps[t1].ContainsKey (t2))
                return ConvOps[t1][t2];

            MethodInfo op = t1.GetMethod (
                "op_Implicit", new[] { t2 });

            lock (ConvOpsLock) {
                try {
                    ConvOps[t1].Add (t2, op);
                } catch (ArgumentException) {
                    return ConvOps[t1][t2];
                }
            }

            return op;
        }

        private static object ReadValue (Type instType, JsonReader reader)
        {
            reader.Read ();

            if (reader.Token == JsonToken.ArrayEnd)
                return null;

            if (reader.Token == JsonToken.Null) {

                if (! instType.IsClass)
                    throw new JsonException (String.Format (
                            "Can't assign null to an instance of type {0}",
                            instType));

                return null;
            }

            if (reader.Token == JsonToken.Double ||
                reader.Token == JsonToken.Int ||
                reader.Token == JsonToken.Long ||
                reader.Token == JsonToken.String ||
                reader.Token == JsonToken.Boolean) {

                Type jsonType = reader.Value.GetType ();

                // juggle between int and long
                if (jsonType == typeof(int) && instType == typeof(long))
                    return (long)((int)(reader.Value));

                // juggle between int and string
                if (jsonType == typeof(string) && instType == typeof(int))
                    return int.Parse((string)(reader.Value));

                // juggle between long and string
                if (jsonType == typeof(string) && instType == typeof(long))
                    return long.Parse((string)(reader.Value));

                if (instType.IsAssignableFrom (jsonType))
                    return reader.Value;

                // If there's a custom importer that fits, use it
                if (CustomImportersTable.ContainsKey (jsonType) &&
                    CustomImportersTable[jsonType].ContainsKey (
                        instType)) {

                    ImporterFunc importer =
                        CustomImportersTable[jsonType][instType];

                    return importer (reader.Value);
                }

                // Maybe there's a base importer that works
                if (BaseImportersTable.ContainsKey (jsonType) &&
                    BaseImportersTable[jsonType].ContainsKey (
                        instType)) {

                    ImporterFunc importer =
                        BaseImportersTable[jsonType][instType];

                    return importer (reader.Value);
                }

                // Maybe it's an enum
                if (instType.IsEnum)
                    return Enum.ToObject (instType, reader.Value);

                // Try using an implicit conversion operator
                MethodInfo convOp = GetConvOp (instType, jsonType);

                if (convOp != null)
                    return convOp.Invoke (null,
                                           new[] { reader.Value });

                // No luck
                throw new JsonException (String.Format (
                        "Can't assign value '{0}' (type {1}) to type {2}",
                        reader.Value, jsonType, instType));
            }

            object instance = null;

            if (reader.Token == JsonToken.ArrayStart) {

                AddArrayMetadata (instType);
                ArrayMetadata tData = ArrayMetadata[instType];

                if (! tData.IsArray && ! tData.IsList)
                    throw new JsonException (String.Format (
                            "Type {0} can't act as an array",
                            instType));

                IList list;
                Type elemType;

                if (! tData.IsArray) {
                    list = (IList) Activator.CreateInstance (instType);
                    elemType = tData.ElementType;
                } else {
                    list = new ArrayList ();
                    elemType = instType.GetElementType ();
                }

                while (true) {
                    object item = ReadValue (elemType, reader);
                    if (reader.Token == JsonToken.ArrayEnd)
                        break;

                    list.Add (item);
                }

                if (tData.IsArray) {
                    int n = list.Count;
                    instance = Array.CreateInstance (elemType, n);

                    for (int i = 0; i < n; i++)
                        ((Array) instance).SetValue (list[i], i);
                } else
                    instance = list;

            } else if (reader.Token == JsonToken.ObjectStart) {

                AddObjectMetadata (instType);
                ObjectMetadata tData = ObjectMetadata[instType];

                instance = Activator.CreateInstance (instType);

                while (true) {
                    reader.Read ();

                    if (reader.Token == JsonToken.ObjectEnd)
                        break;

                    if (reader.Value == null)
                        continue;
                    
                    var property = reader.Value.ToString();
                    char[] chars = property.ToCharArray();
                    for (int i = 0; i < chars.Length; i++)
                    {
                        if (i == 0 || (i > 0 && property[i - 1] == '_'))
                            chars[i] = Char.ToUpper(property[i]);
                    }
                    var formattedProperty = new string(chars).Replace("_", string.Empty);

                    if (tData.Properties.ContainsKey(formattedProperty))
                        {
                            PropertyMetadata propData =
                                tData.Properties[formattedProperty];

                            if (propData.IsField)
                            {
                                ((FieldInfo)propData.Info).SetValue(
                                    instance, ReadValue(propData.Type, reader));
                            }
                            else
                            {
                                var pInfo =
                                    (PropertyInfo)propData.Info;

                                if (pInfo.CanWrite)
                                    pInfo.SetValue(
                                        instance,
                                        ReadValue(propData.Type, reader),
                                        null);
                                else
                                    ReadValue(propData.Type, reader);
                            }

                        }
                        else
                        {
                            //if (!tData.IsDictionary)
                            //    throw new JsonException(String.Format(
                            //            "The type {0} doesn't have the " +
                            //            "property '{1}'", instType, property));

                            if (tData.IsDictionary)
                                ((IDictionary)instance).Add(
                                    property, ReadValue(
                                        tData.ElementType, reader));
                        }

                }

            }

            return instance;
        }

        private static IJsonWrapper ReadValue (WrapperFactory factory,
                                               JsonReader reader)
        {
            reader.Read ();

            if (reader.Token == JsonToken.ArrayEnd ||
                reader.Token == JsonToken.Null)
                return null;

            IJsonWrapper instance = factory ();

            if (reader.Token == JsonToken.String) {
                instance.SetString ((string) reader.Value);
                return instance;
            }

            if (reader.Token == JsonToken.Double) {
                instance.SetDouble ((double) reader.Value);
                return instance;
            }

            if (reader.Token == JsonToken.Int) {
                instance.SetInt ((int) reader.Value);
                return instance;
            }

            if (reader.Token == JsonToken.Long) {
                instance.SetLong ((long) reader.Value);
                return instance;
            }

            if (reader.Token == JsonToken.Boolean) {
                instance.SetBoolean ((bool) reader.Value);
                return instance;
            }

            if (reader.Token == JsonToken.ArrayStart) {
                instance.SetJsonType (JsonType.Array);

                while (true) {
                    IJsonWrapper item = ReadValue (factory, reader);
                    if (reader.Token == JsonToken.ArrayEnd)
                        break;

                    instance.Add (item);
                }
            }
            else if (reader.Token == JsonToken.ObjectStart) {
                instance.SetJsonType (JsonType.Object);

                while (true) {
                    reader.Read ();

                    if (reader.Token == JsonToken.ObjectEnd)
                        break;

                    var property = (string) reader.Value;

                    instance[property] = ReadValue (
                        factory, reader);
                }

            }

            return instance;
        }

        private static void RegisterBaseExporters ()
        {
            BaseExportersTable[typeof (byte)] =
                (obj, writer) => writer.Write(Convert.ToInt32((byte) obj));

            BaseExportersTable[typeof (char)] =
                (obj, writer) => writer.Write(Convert.ToString((char) obj));

            BaseExportersTable[typeof (DateTime)] =
                (obj, writer) => writer.Write(Convert.ToString((DateTime) obj,
                                                               DatetimeFormat));

            BaseExportersTable[typeof (decimal)] =
                (obj, writer) => writer.Write((decimal) obj);

            BaseExportersTable[typeof (sbyte)] =
                (obj, writer) => writer.Write(Convert.ToInt32((sbyte) obj));

            BaseExportersTable[typeof (short)] =
                (obj, writer) => writer.Write(Convert.ToInt32((short) obj));

            BaseExportersTable[typeof (ushort)] =
                (obj, writer) => writer.Write(Convert.ToInt32((ushort) obj));

            BaseExportersTable[typeof (uint)] =
                (obj, writer) => writer.Write(Convert.ToUInt64((uint) obj));

            BaseExportersTable[typeof (ulong)] =
                (obj, writer) => writer.Write((ulong) obj);
        }

        private static void RegisterBaseImporters ()
        {
            ImporterFunc importer = input => Convert.ToByte((int) input);
            RegisterImporter (BaseImportersTable, typeof (int),
                              typeof (byte), importer);

            importer = input => Convert.ToUInt64((int) input);
            RegisterImporter (BaseImportersTable, typeof (int),
                              typeof (ulong), importer);

            importer = input => Convert.ToSByte((int) input);
            RegisterImporter (BaseImportersTable, typeof (int),
                              typeof (sbyte), importer);

            importer = input => Convert.ToInt16((int) input);
            RegisterImporter (BaseImportersTable, typeof (int),
                              typeof (short), importer);

            importer = input => Convert.ToUInt16((int) input);
            RegisterImporter (BaseImportersTable, typeof (int),
                              typeof (ushort), importer);

            importer = input => Convert.ToUInt32((int) input);
            RegisterImporter (BaseImportersTable, typeof (int),
                              typeof (uint), importer);

            importer = input => Convert.ToSingle((int) input);
            RegisterImporter (BaseImportersTable, typeof (int),
                              typeof (float), importer);

            importer = input => Convert.ToDouble((int) input);
            RegisterImporter (BaseImportersTable, typeof (int),
                              typeof (double), importer);

            importer = input => Convert.ToDecimal((double) input);
            RegisterImporter (BaseImportersTable, typeof (double),
                              typeof (decimal), importer);


            importer = input => Convert.ToUInt32((long) input);
            RegisterImporter (BaseImportersTable, typeof (long),
                              typeof (uint), importer);

            importer = input => Convert.ToChar((string) input);
            RegisterImporter (BaseImportersTable, typeof (string),
                              typeof (char), importer);

            importer = input => Convert.ToDateTime((string) input, DatetimeFormat);
            RegisterImporter (BaseImportersTable, typeof (string),
                              typeof (DateTime), importer);
        }

        private static void RegisterImporter (
            IDictionary<Type, IDictionary<Type, ImporterFunc>> table,
            Type jsonType, Type valueType, ImporterFunc importer)
        {
            if (! table.ContainsKey (jsonType))
                table.Add (jsonType, new Dictionary<Type, ImporterFunc> ());

            table[jsonType][valueType] = importer;
        }

        private static void WriteValue (object obj, JsonWriter writer,
                                        bool writerIsPrivate,
                                        int depth)
        {
            if (depth > MaxNestingDepth)
                throw new JsonException (
                    String.Format ("Max allowed object depth reached while " +
                                   "trying to export from type {0}",
                                   obj.GetType ()));

            if (obj == null) {
                writer.Write (null);
                return;
            }

            var wrapper = obj as IJsonWrapper;
            if (wrapper != null) {
                if (writerIsPrivate)
                    writer.TextWriter.Write (wrapper.ToJson ());
                else
                    wrapper.ToJson (writer);

                return;
            }

            var s = obj as string;
            if (s != null) {
                writer.Write (s);
                return;
            }

            if (obj is Double) {
                writer.Write ((double) obj);
                return;
            }

            if (obj is Int32) {
                writer.Write ((int) obj);
                return;
            }

            if (obj is Boolean) {
                writer.Write ((bool) obj);
                return;
            }

            if (obj is Int64) {
                writer.Write ((long) obj);
                return;
            }

            var array = obj as Array;
            if (array != null) {
                writer.WriteArrayStart ();

                foreach (object elem in array)
                    WriteValue (elem, writer, writerIsPrivate, depth + 1);

                writer.WriteArrayEnd ();

                return;
            }

            var list = obj as IList;
            if (list != null) {
                writer.WriteArrayStart ();
                foreach (object elem in list)
                    WriteValue (elem, writer, writerIsPrivate, depth + 1);
                writer.WriteArrayEnd ();

                return;
            }

            var entries = obj as IDictionary;
            if (entries != null) {
                writer.WriteObjectStart ();
                foreach (DictionaryEntry entry in entries) {
                    writer.WritePropertyName ((string) entry.Key);
                    WriteValue (entry.Value, writer, writerIsPrivate,
                                depth + 1);
                }
                writer.WriteObjectEnd ();

                return;
            }

            Type objType = obj.GetType ();

            // See if there's a custom exporter for the object
            if (CustomExportersTable.ContainsKey (objType)) {
                ExporterFunc exporter = CustomExportersTable[objType];
                exporter (obj, writer);

                return;
            }

            // If not, maybe there's a base exporter
            if (BaseExportersTable.ContainsKey (objType)) {
                ExporterFunc exporter = BaseExportersTable[objType];
                exporter (obj, writer);

                return;
            }

            // Last option, let's see if it's an enum
            if (obj is Enum) {
                Type eType = Enum.GetUnderlyingType (objType);

                if (eType == typeof (long)
                    || eType == typeof (uint)
                    || eType == typeof (ulong))
                    writer.Write ((ulong) obj);
                else
                    writer.Write ((int) obj);

                return;
            }

            // Okay, so it looks like the input should be exported as an
            // object
            AddTypeProperties (objType);
            IList<PropertyMetadata> props = TypeProperties[objType];

            writer.WriteObjectStart ();
            foreach (PropertyMetadata pData in props) {
                if (pData.IsField) {
                    writer.WritePropertyName (pData.Info.Name);
                    WriteValue (((FieldInfo) pData.Info).GetValue (obj),
                                writer, writerIsPrivate, depth + 1);
                }
                else {
                    var pInfo = (PropertyInfo) pData.Info;

                    if (pInfo.CanRead) {
                        writer.WritePropertyName (pData.Info.Name);
                        WriteValue (pInfo.GetValue (obj, null),
                                    writer, writerIsPrivate, depth + 1);
                    }
                }
            }
            writer.WriteObjectEnd ();
        }
        #endregion


        public static string ToJson (object obj)
        {
            lock (StaticWriterLock) {
                StaticWriter.Reset ();

                WriteValue (obj, StaticWriter, true, 0);

                return StaticWriter.ToString ();
            }
        }

        public static void ToJson (object obj, JsonWriter writer)
        {
            WriteValue (obj, writer, false, 0);
        }

        public static JsonData ToObject (JsonReader reader)
        {
            return (JsonData) ToWrapper (
                () => new JsonData(), reader);
        }

        public static JsonData ToObject (TextReader reader)
        {
            var jsonReader = new JsonReader (reader);

            return (JsonData) ToWrapper (
                () => new JsonData(), jsonReader);
        }

        public static JsonData ToObject (string json)
        {
            return (JsonData) ToWrapper (
                () => new JsonData(), json);
        }

        public static T ToObject<T> (JsonReader reader)
        {
            return (T) ReadValue (typeof (T), reader);
        }

        public static T ToObject<T> (TextReader reader)
        {
            var jsonReader = new JsonReader (reader);

            return (T) ReadValue (typeof (T), jsonReader);
        }

        public static T ToObject<T> (string json)
        {
            var reader = new JsonReader (json);

            return (T) ReadValue (typeof (T), reader);
        }

        public static IJsonWrapper ToWrapper (WrapperFactory factory,
                                              JsonReader reader)
        {
            return ReadValue (factory, reader);
        }

        public static IJsonWrapper ToWrapper (WrapperFactory factory,
                                              string json)
        {
            var reader = new JsonReader (json);

            return ReadValue (factory, reader);
        }

        public static void RegisterExporter<T> (ExporterFunc<T> exporter)
        {
            ExporterFunc exporterWrapper =
                (obj, writer) => exporter((T) obj, writer);

            CustomExportersTable[typeof (T)] = exporterWrapper;
        }

        public static void RegisterImporter<TJson, TValue> (
            ImporterFunc<TJson, TValue> importer)
        {
            ImporterFunc importerWrapper =
                input => importer((TJson) input);

            RegisterImporter (CustomImportersTable, typeof (TJson),
                              typeof (TValue), importerWrapper);
        }

        public static void UnregisterExporters ()
        {
            CustomExportersTable.Clear ();
        }

        public static void UnregisterImporters ()
        {
            CustomImportersTable.Clear ();
        }
    }
}
