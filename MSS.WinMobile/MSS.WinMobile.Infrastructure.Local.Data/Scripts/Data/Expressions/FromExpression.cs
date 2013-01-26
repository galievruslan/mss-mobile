namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data.Expressions
{
    public class FromExpression : Expression
    {
        private readonly string _tableName;

        public FromExpression(string tableName)
        {
            _tableName = tableName;
        }

        private string _alias;

        public FromExpression As(string alias)
        {
            _alias = alias;
            return this;
        }

        private const string AliasedPattern = "{0} AS {1}";
        private const string Pattern = "{0}";

        public override string AsSql()
        {
            return string.IsNullOrEmpty(_alias)
                       ? string.Format(Pattern, _tableName)
                       : string.Format(AliasedPattern, _tableName, _alias);
        }
    }
}
