using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class PriceListQueryObject : QueryObject<PriceList>
    {
        public PriceListQueryObject(SQLiteConnectionFactory connectionFactory, ITranslator<PriceList> translator)
            : base(connectionFactory, translator)
        {
        }

        public PriceListQueryObject(IQueryObject<PriceList, string, SQLiteConnection> queryObject)
            : base(queryObject)
        {
        }

        private const string SelectQuery = "SELECT Id, Name FROM PriceLists";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
