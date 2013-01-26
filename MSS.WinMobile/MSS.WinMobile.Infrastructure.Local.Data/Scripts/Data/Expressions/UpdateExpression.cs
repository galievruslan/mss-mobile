using System.Collections.Generic;
using System.Text;

namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data.Expressions
{
    public class UpdateExpression : Expression
    {
        private readonly IDictionary<ItemExpression, ValueExpression> _updatePairs =
            new Dictionary<ItemExpression, ValueExpression>();

        public UpdateExpression Update(ItemExpression itemExpression, ValueExpression valueExpression)
        {
            if (!_updatePairs.ContainsKey(itemExpression))
                _updatePairs.Add(itemExpression, valueExpression);
            else
                _updatePairs[itemExpression] = valueExpression;

            return this;
        }

        private const string ItemPattern = "{0} = {1}";

        public override string AsSql()
        {
            var stringBuilder = new StringBuilder();
            foreach (var pair in _updatePairs)
            {
                if (stringBuilder.Length > 0)
                    stringBuilder.Append(",\n");

                stringBuilder.Append(string.Format(ItemPattern, pair.Key.AsSql(), pair.Value.AsSql()));
            }

            return stringBuilder.ToString();
        }
    }
}
