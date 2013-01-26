using MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data.Expressions;

namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data
{
    public class UpdateScript : Script
    {
        private readonly string _tableName;

        public UpdateScript(string tableName)
        {
            _tableName = tableName;
        }

        private UpdateExpression _updateExpression;

        public UpdateScript How(UpdateExpression updateExpression)
        {
            _updateExpression = updateExpression;
            return this;
        }

        private WhereExpression _whereExpression;

        public UpdateScript Where(WhereExpression whereExpression)
        {
            _whereExpression = whereExpression;
            return this;
        }

        private const string Pattern = "UPDATE {0}\n{1}";
        private const string WherePattern = "UPDATE {0}\nSET\n{1}\nWHERE{2}";

        public override string Text
        {
            get
            {
                if (_whereExpression == null)
                    return string.Format(Pattern, _tableName, _updateExpression.AsSql());

                return string.Format(WherePattern, _tableName, _updateExpression.AsSql(), _whereExpression.AsSql());
            }
        }
    }
}
