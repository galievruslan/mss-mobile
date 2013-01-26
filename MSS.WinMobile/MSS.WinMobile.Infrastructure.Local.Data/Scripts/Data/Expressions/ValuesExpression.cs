using System.Collections.Generic;
using System.Text;

namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data.Expressions
{
    public class ValuesExpression : Expression
    {
        readonly List<ValueExpression> _valueExpressions = new List<ValueExpression>();

        public ValuesExpression What(ValueExpression valueExpression)
        {
            _valueExpressions.Add(valueExpression);
            return this;
        }

        private const string Pattern = "VALUES ({0})";

        public override string AsSql()
        {
            var selectExpressionBuilder = new StringBuilder();
            for (int i = 0; i < _valueExpressions.Count; i++)
            {
                selectExpressionBuilder.Append(_valueExpressions[i].AsSql());
                if (i != _valueExpressions.Count - 1)
                {
                    selectExpressionBuilder.Append(",");
                }
                selectExpressionBuilder.Append("\n");
            }

            return string.Format(Pattern, selectExpressionBuilder);
        }
    }
}
