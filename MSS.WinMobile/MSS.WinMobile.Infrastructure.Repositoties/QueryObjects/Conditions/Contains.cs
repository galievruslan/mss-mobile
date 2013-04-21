namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects.Conditions
{
    public class Contains : Condition
    {
        private readonly string _queryCondition;

        public Contains(string value)
        {
            _queryCondition = string.Format(" LIKE '%{0}%'", value);
        }

        public override string ToString()
        {
            return _queryCondition;
        }
    }
}
