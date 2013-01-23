using System;

namespace MSS.WinMobile.Infrastructure.Local.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ReferenceAttribute : ColumnAttribute
    {
        public ReferenceAttribute(string name, Type referencedType) 
            : base(name)
        {
            ReferencedType = referencedType;
        }

        public readonly Type ReferencedType;
    }
}
