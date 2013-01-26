using MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data.Expressions;

namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data
{
    public class SelectScript : Script
    {
        private SelectExpression _selectExpression;

        public SelectScript What(SelectExpression selectExpression)
        {
            _selectExpression = selectExpression;
            return this;
        }

        private FromExpression _fromExpression;

        public SelectScript From(FromExpression fromExpression)
        {
            _fromExpression = fromExpression;
            return this;
        }

        private WhereExpression _whereExpression;

        public SelectScript Where(WhereExpression whereExpression)
        {
            _whereExpression = whereExpression;
            return this;
        }

        private const string Pattern = "SELECT\n\t{0}\nFROM\n\t{1}";
        private const string PatternWithWhere = "SELECT\n\t{0}\nFROM\n\t{1}\nWHERE\n\t{2}";

        public override string Text
        {
            get
            {
                return _whereExpression == null
                           ? string.Format(Pattern, _selectExpression.AsSql(), _fromExpression.AsSql())
                           : string.Format(PatternWithWhere, _selectExpression.AsSql(), _fromExpression.AsSql(),
                                           _whereExpression.AsSql());
            }
        }
    }
}
