using System;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions
{
    public class Equals : Condition
    {
        private readonly string _queryCondition;

        public Equals(string value)
        {
            _queryCondition = string.Format(" = '{0}'", value);
        }

        public Equals(int value)
        {
            _queryCondition = string.Format(" = {0}", value);
        }

        public Equals(bool value)
        {
            _queryCondition = string.Format(" = {0}", value ? 1 : 0);
        }

        public Equals(Guid value)
        {
            _queryCondition = string.Format(" = '{0}'", value);
        }

        public Equals(decimal value)
        {
            _queryCondition = string.Format(" = {0}", value);
        }

        public Equals(DateTime value)
        {
            _queryCondition = string.Format(" = '{0}'", value);
        }

        public override string ToString()
        {
            return _queryCondition;
        }
    }
}
