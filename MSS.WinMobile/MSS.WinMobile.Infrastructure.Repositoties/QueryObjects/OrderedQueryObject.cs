using System.Data.SQLite;
using System.Text;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class OrderedQueryObject<TModel> : QueryObject<TModel> where TModel : IModel {
        private readonly string _innerQuery;
        private string OrderByField { get; set; }
        private OrderDirection OrderDirection { get; set; }

        public OrderedQueryObject(IStorage storage,
                                  ISpecificationTranslator<TModel> specificationTranslator,
                                  DataRecordTranslator<TModel> translator, string innerQuery, string orderByField,
                                  OrderDirection orderDirection)
            : base(storage, specificationTranslator, translator) {
            _innerQuery = innerQuery;
            OrderByField = orderByField;
            OrderDirection = orderDirection;
        }

        protected override string AsQuery()
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append(string.Format("{0} ORDER BY [{1}] ", _innerQuery, OrderByField));
            queryStringBuilder.Append(OrderDirection == OrderDirection.Asceding ? "ASC " : "DESC ");
            return queryStringBuilder.ToString();
        }
    }
}
