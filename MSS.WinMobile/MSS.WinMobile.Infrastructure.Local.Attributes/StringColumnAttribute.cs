using System;
using System.Data;

namespace MSS.WinMobile.Infrastructure.Local.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class StringColumnAttribute : ColumnAttribute
    {
        public StringColumnAttribute(string name, int lenght)
            :base(name)
        {
            Lenght = lenght;
        }

        public readonly int Lenght;
    }
}
