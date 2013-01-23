using System;
using System.Data;

namespace MSS.WinMobile.Infrastructure.Local.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DecimalColumnAttribute : ColumnAttribute
    {
        public DecimalColumnAttribute(string name, int precision, int scale)
            :base(name)
        {
            Precision = precision;
            Scale = scale;
        }

        public readonly int Precision;

        public readonly int Scale;
    }
}
