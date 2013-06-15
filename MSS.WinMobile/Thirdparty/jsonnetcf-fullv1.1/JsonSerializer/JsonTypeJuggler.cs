using System;

namespace Json
{
    class JsonTypeJuggler
    {
        public static bool IsInt(Object o)
        {
            return IsInt(o.GetType());
        }

        public static bool IsInt(Type t)
        {
            string name = t.Name;
            return String.Compare(name, typeof(int).Name, StringComparison.Ordinal) == 0
                   || String.Compare(name, typeof(Int32).Name, StringComparison.Ordinal) == 0
                   || String.Compare(name, typeof(Int16).Name, StringComparison.Ordinal) == 0;
        }

        public static bool IsLong(Object o)
        {
            return IsLong(o.GetType());
        }

        public static bool IsLong(Type t)
        {
            string name = t.Name;
            return String.Compare(name, typeof(long).Name, StringComparison.Ordinal) == 0
                   || String.Compare(name, typeof(Int64).Name, StringComparison.Ordinal) == 0;
        }

        public static bool IsBool(Object o)
        {
            return IsBool(o.GetType());
        }

        public static bool IsBool(Type t)
        {
            string name = t.Name;
            return String.Compare(name, typeof(bool).Name, StringComparison.Ordinal) == 0
                   || String.Compare(name, typeof(Boolean).Name, StringComparison.Ordinal) == 0;
        }

        public static bool IsDouble(Object o)
        {
            return IsDouble(o.GetType());
        }

        public static bool IsDouble(Type t)
        {
            string name = t.Name;
            return String.Compare(name, typeof(double).Name, StringComparison.Ordinal) == 0
                   || String.Compare(name, typeof(Double).Name, StringComparison.Ordinal) == 0;
        }

        public static bool IsString(Object o)
        {
            return IsString(o.GetType());
        }

        public static bool IsString(Type t)
        {
            string name = t.Name;
            return String.Compare(name, typeof(string).Name, StringComparison.Ordinal) == 0
                   || String.Compare(name, typeof(String).Name, StringComparison.Ordinal) == 0;
        }

        public static bool IsArray(Object o)
        {
            return IsArray(o.GetType());
        }

        public static bool IsArray(Type t)
        {
            return t.IsArray;
        }
    }
}
