using System;

namespace MSS.WinMobile.Infrastructure.Local.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class KeyAttribute : ColumnAttribute
    {
        public KeyAttribute(string name) 
            : base(name)
        {
        }
    }
}
