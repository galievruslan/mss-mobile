using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    class JsonTypeJuggler
    {
        public static bool isInt(Object o)
        {
            return isInt(o.GetType());
        }

        public static bool isInt(Type t)
        {
            string name = t.Name;
            if (name.CompareTo(typeof(int).Name) == 0
                || name.CompareTo(typeof(Int32).Name) == 0
                || name.CompareTo(typeof(Int16).Name) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isLong(Object o)
        {
            return isLong(o.GetType());
        }

        public static bool isLong(Type t)
        {
            string name = t.Name;
            if (name.CompareTo(typeof(long).Name) == 0
                || name.CompareTo(typeof(Int64).Name) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isBool(Object o)
        {
            return isBool(o.GetType());
        }

        public static bool isBool(Type t)
        {
            string name = t.Name;
            if (name.CompareTo(typeof(bool).Name) == 0
                || name.CompareTo(typeof(Boolean).Name) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isDouble(Object o)
        {
            return isDouble(o.GetType());
        }

        public static bool isDouble(Type t)
        {
            string name = t.Name;
            if (name.CompareTo(typeof(double).Name) == 0
                || name.CompareTo(typeof(Double).Name) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isString(Object o)
        {
            return isString(o.GetType());
        }

        public static bool isString(Type t)
        {
            string name = t.Name;
            if (name.CompareTo(typeof(string).Name) == 0
                || name.CompareTo(typeof(String).Name) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isArray(Object o)
        {
            return isArray(o.GetType());
        }

        public static bool isArray(Type t)
        {
            return t.IsArray;
        }
    }
}
