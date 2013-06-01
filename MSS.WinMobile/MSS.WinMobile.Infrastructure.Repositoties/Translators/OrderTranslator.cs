using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators
{
    public class OrderDataRecordTranslator : DataRecordTranslator<Order> {
        private readonly IRepositoryFactory _repositoryFactory;
        public OrderDataRecordTranslator(IRepositoryFactory repositoryFactory) {
            _repositoryFactory = repositoryFactory;
        }

        protected override Order TranslateOne(IDataRecord value)
        {
            var proxy = new OrderProxy(_repositoryFactory.CreateRepository<OrderItem>()) {
                Id = value.GetInt32(value.GetOrdinal("Id")),
                RoutePointId = value.GetInt32(value.GetOrdinal("RoutePoint_Id")),
                OrderDate = value.GetDateTime(value.GetOrdinal("OrderDate")),
                ShippingDate = value.GetDateTime(value.GetOrdinal("ShippingDate")),
                CustomerId = value.GetInt32(value.GetOrdinal("Customer_Id")),
                CustomerName = value.GetString(value.GetOrdinal("Customer_Name")),
                ShippingAddressId = value.GetInt32(value.GetOrdinal("ShippingAddress_Id")),
                ShippingAddressName = value.GetString(value.GetOrdinal("ShippingAddress_Name")),
                PriceListId = value.GetInt32(value.GetOrdinal("PriceList_Id")),
                PriceListName = value.GetString(value.GetOrdinal("PriceList_Name")),
                WarehouseId = value.GetInt32(value.GetOrdinal("Warehouse_Id")),
                WarehouseName = value.GetString(value.GetOrdinal("Warehouse_Name")),
                Amount = value.GetDecimal(value.GetOrdinal("Amount")),
                OrderStatus = (OrderStatus) value.GetInt32(value.GetOrdinal("OrderStatus")),
                Note = value.GetString(value.GetOrdinal("Note")),
                Synchronized = value.GetBoolean(value.GetOrdinal("Synchronized")),
                GUID = value.GetGuid(value.GetOrdinal("GUID"))
            };
            return proxy;
        }
    }
}
