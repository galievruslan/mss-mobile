using System;
using System.Data;

namespace MSS.WinMobile.Infrastructure.Local.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class BooleanColumnAttribute : ColumnAttribute
    {
        public BooleanColumnAttribute(string name)
            :base(name)
        {
        }
    }
}
