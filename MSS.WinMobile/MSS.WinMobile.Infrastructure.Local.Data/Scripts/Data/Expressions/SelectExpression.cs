using System;

using System.Collections.Generic;
using System.Text;

namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data.Expressions
{
    public class SelectExpression : Expression
    {
        readonly List<ItemExpression> _itemExpressions = new List<ItemExpression>(); 

        public SelectExpression What(ItemExpression itemExpression)
        {
            _itemExpressions.Add(itemExpression);
            return this;
        }

        private const string Pattern = "{0}";

        public override string AsSql()
        {
            var selectExpressionBuilder = new StringBuilder();
            for (int i = 0; i < _itemExpressions.Count; i++)
            {
                selectExpressionBuilder.Append(_itemExpressions[i].AsSql());
                if (i != _itemExpressions.Count - 1)
                {
                    selectExpressionBuilder.Append(",");
                }
                selectExpressionBuilder.Append("\n");
            }

            return string.Format(Pattern, selectExpressionBuilder);
        }
    }
}
