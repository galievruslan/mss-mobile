using System;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions
{
    public class Less : Condition
    {
        private readonly string _queryCondition;

        public Less(string value)
        {
            _queryCondition = string.Format(" < '{0}'", value);
        }

        public Less(int value)
        {
            _queryCondition = string.Format(" < {0}", value);
        }

        public Less(bool value)
        {
            _queryCondition = string.Format(" < {0}", value ? 1 : 0);
        }

        public Less(Guid value)
        {
            _queryCondition = string.Format(" < '{0}'", value);
        }

        public Less(decimal value)
        {
            _queryCondition = string.Format(" < {0}", value);
        }

        public Less(DateTime value)
        {
            _queryCondition = string.Format(" < '{0}'", value);
        }

        public override string ToString()
        {
            return _queryCondition;
        }
    }
}
