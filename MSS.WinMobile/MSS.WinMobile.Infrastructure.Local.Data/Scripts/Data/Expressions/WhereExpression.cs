namespace MSS.WinMobile.Infrastructure.Local.Data.Scripts.Data.Expressions
{
    public class WhereExpression : Expression
    {
        private readonly ItemExpression _itemExpression;

        public WhereExpression(ItemExpression itemExpression)
        {
            _itemExpression = itemExpression;
        }
        
        private string _condition;
        private ValueExpression _valueExpression;

        public WhereExpression GreatherThan(ValueExpression valueExpression)
        {
            _condition = string.Format(" > ");
            _valueExpression = valueExpression;
            return this;
        }

        public WhereExpression GreatherOrEqualsThan(ValueExpression valueExpression)
        {
            _condition = string.Format(" >= ");
            _valueExpression = valueExpression;
            return this;
        }

        public WhereExpression LessThan(ValueExpression valueExpression)
        {
            _condition = string.Format(" < ");
            _valueExpression = valueExpression;
            return this;
        }

        public WhereExpression LessOrEqualsThan(ValueExpression valueExpression)
        {
            _condition = string.Format(" <= ");
            _valueExpression = valueExpression;
            return this;
        }

        public WhereExpression Equals(ValueExpression valueExpression)
        {
            _condition = string.Format(" = ");
            _valueExpression = valueExpression;
            return this;
        }

        public override string AsSql()
        {
            return string.Format("{0}{1}{2}", _itemExpression.AsSql(), _condition, _valueExpression.AsSql());
        }
    }
}
