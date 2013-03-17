using System;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions
{
    public class Greather : Condition
    {
        private readonly string _queryCondition;

        public Greather(string value)
        {
            _queryCondition = string.Format(" > '{0}'", value);
        }

        public Greather(int value)
        {
            _queryCondition = string.Format(" > {0}", value);
        }

        public Greather(bool value)
        {
            _queryCondition = string.Format(" > {0}", value ? 1 : 0);
        }

        public Greather(Guid value)
        {
            _queryCondition = string.Format(" > '{0}'", value);
        }

        public Greather(decimal value)
        {
            _queryCondition = string.Format(" > {0}", value);
        }

        public Greather(DateTime value)
        {
            _queryCondition = string.Format(" > '{0}'", value);
        }

        public override string ToString()
        {
            return _queryCondition;
        }
    }
}
