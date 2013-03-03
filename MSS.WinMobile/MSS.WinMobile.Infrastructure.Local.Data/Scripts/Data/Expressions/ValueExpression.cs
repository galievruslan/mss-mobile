using System;

namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data.Expressions
{
    public class ValueExpression : Expression
    {
        private readonly object _value;

        public ValueExpression(object value)
        {
            _value = value;
        }

        private const string DatetimePattern = @"'{0}'";
        private const string StringPattern = @"'{0}'";
        private const string BooleanPattern = @"{0}";
        private const string OtherPattern = @"{0}";

        public override string AsSql()
        {
            if (_value == null)
                return "NULL";
            if (_value is string)
                return string.Format(StringPattern, _value);
            if (_value is bool)
            {
                return (bool) _value ? string.Format(BooleanPattern, 1) : string.Format(BooleanPattern, 0);
            }
            if (_value is DateTime)
                return string.Format(DatetimePattern, ((DateTime)_value).ToString("yyyy-MM-dd HH:mm:ss"));

            return string.Format(OtherPattern, _value);
        }
    }
}
