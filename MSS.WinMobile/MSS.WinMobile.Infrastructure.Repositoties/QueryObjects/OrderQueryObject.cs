using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class OrderQueryObject : QueryObject<Order>
    {
        public OrderQueryObject(SQLiteConnectionFactory connectionFactory, ITranslator<Order> translator)
            : base(connectionFactory, translator)
        {
        }

        public OrderQueryObject(IQueryObject<Order, string, SQLiteConnection> queryObject)
            : base(queryObject)
        {
        }

        private const string SelectQuery =
            "SELECT orders.Id, orders.RoutePoint_Id, orders.OrderDate, orders.ShippingDate, orders.Manager_Id, " +
            "customers.Id as [Customer_Id], customers.Name as [Customer_Name], orders.ShippingAddress_Id, shipping_addresses.Name as [ShippingAddress_Name], orders.PriceList_Id, " +
            " priceLists.Name as [PriceList_Name], orders.Warehouse_Id, warehouses.Address as [Warehouse_Name], orders.OrderStatus, orders.Note " +
            " FROM Orders orders Left join Managers managers on orders.[Manager_Id] = managers.[Id] " +
            " Left join ShippingAddresses shipping_addresses on orders.[ShippingAddress_Id] = shipping_addresses.[Id] " +
            " Left join Customers customers on  shipping_addresses.[Customer_Id] = customers.[Id] " +
            " Left join PriceLists priceLists on orders.[PriceList_Id] = priceLists.[Id] " +
            " Left join Warehouses warehouses on orders.[Warehouse_Id] = warehouses.[Id]";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
