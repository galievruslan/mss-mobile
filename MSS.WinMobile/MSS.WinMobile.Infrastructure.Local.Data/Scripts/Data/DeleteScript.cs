using MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data.Expressions;

namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data
{
    public class DeleteScript : Script
    {
        private readonly string _tableName;

        public DeleteScript(string tableName)
        {
            _tableName = tableName;
        }

        private WhereExpression _whereExpression;

        public DeleteScript Where(WhereExpression whereExpression)
        {
            _whereExpression = whereExpression;
            return this;
        }

        private const string Pattern = "DELETE FROM {0}";
        private const string WherePattern = "DELETE FROM {0}\nWHERE{1}";

        public override string Text
        {
            get
            {
                if (_whereExpression == null)
                    return string.Format(Pattern, _tableName);

                return string.Format(WherePattern, _tableName, _whereExpression.AsSql());
            }
        }
    }
}
