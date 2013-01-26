using MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data.Expressions;

namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data
{
    public class InsertScript : Script
    {
        private readonly string _tableName;

        public InsertScript(string tableName)
        {
            _tableName = tableName;
        }

        private InsertExpression _insertIntoExpression;

        public InsertScript How(InsertExpression insertIntoExpression)
        {
            _insertIntoExpression = insertIntoExpression;
            return this;
        }

        private ValuesExpression _valuesExpression;

        public InsertScript What(ValuesExpression valuesExpression)
        {
            _valuesExpression = valuesExpression;
            return this;
        }

        private const string Pattern = "INSERT INTO {0}\n\t{1}\n{2}";

        public override string Text
        {
            get { return string.Format(Pattern, _tableName, _insertIntoExpression.AsSql(), _valuesExpression.AsSql()); }
        }
    }
}
