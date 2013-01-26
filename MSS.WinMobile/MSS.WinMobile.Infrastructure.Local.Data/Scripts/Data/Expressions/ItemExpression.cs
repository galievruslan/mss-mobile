namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data.Expressions
{
    public class ItemExpression : Expression
    {
        private readonly string _name;

        public ItemExpression(string name)
        {
            _name = name;
        }

        private string _alias;

        public ItemExpression As(string alias)
        {
            _alias = alias;
            return this;
        }

        private const string Pattern = "[{0}]";
        private const string AliasedPattern = "[{0}] AS {1}";

        public override string AsSql()
        {
            return string.IsNullOrEmpty(_alias) ? string.Format(Pattern, _name) : string.Format(AliasedPattern, _name, _alias);
        }
    }
}
