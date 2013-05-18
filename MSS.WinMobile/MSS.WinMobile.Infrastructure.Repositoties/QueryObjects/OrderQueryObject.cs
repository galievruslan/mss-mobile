using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class OrderQueryObject : QueryObject<Order>
    {
        public OrderQueryObject(IStorage storage,
                                ISpecificationTranslator<Order> specificationTranslator,
                                DataRecordTranslator<Order> translator)
            : base(storage, specificationTranslator, translator) {}

        private const string SelectQuery =
            "SELECT orders.Id, orders.RoutePoint_Id, orders.OrderDate, orders.ShippingDate, " +
            "customers.Id as [Customer_Id], customers.Name as [Customer_Name], orders.ShippingAddress_Id, shipping_addresses.Name as [ShippingAddress_Name], orders.PriceList_Id, " +
            " priceLists.Name as [PriceList_Name], orders.Warehouse_Id, warehouses.Address as [Warehouse_Address], orders.Amount, orders.OrderStatus, orders.Note, orders.Synchronized " +
            " FROM Orders orders " +
            " Left join ShippingAddresses shipping_addresses on orders.[ShippingAddress_Id] = shipping_addresses.[Id] " +
            " Left join Customers customers on  shipping_addresses.[Customer_Id] = customers.[Id] " +
            " Left join PriceLists priceLists on orders.[PriceList_Id] = priceLists.[Id] " +
            " Left join Warehouses warehouses on orders.[Warehouse_Id] = warehouses.[Id]";
        protected override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
