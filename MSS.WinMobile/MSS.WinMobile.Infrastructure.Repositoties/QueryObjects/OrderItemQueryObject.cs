using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class OrderItemQueryObject : QueryObject<OrderItem>
    {
        public OrderItemQueryObject(SqliteConnectionFactory connectionFactory, ITranslator<OrderItem> translator)
            : base(connectionFactory, translator)
        {
        }

        public OrderItemQueryObject(IQueryObject<OrderItem, string, SQLiteConnection> queryObject)
            : base(queryObject)
        {
        }

        private const string SelectQuery =
            "SELECT orderItems.Id, orderItems.Order_Id, orderItems.Product_Id, products.Name as Product_Name, orderItems.Quantity " +
            "FROM OrderItems orderItems Left Join " +
            "Products products on orderItems.Product_Id = products.Id";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
