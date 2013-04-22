﻿using System.Globalization;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(SqliteConnectionFactory connectionFactory, SqliteUnitOfWork unitOfWork)
            : base(connectionFactory, unitOfWork)
        {
        }

        protected override QueryObject<Order> GetQueryObject()
        {
            return new OrderQueryObject(ConnectionFactory, new OrderTranslator());
        }

        private const string SaveQueryTemplate =
            "INSERT OR REPLACE INTO Orders (Id, RoutePoint_Id, OrderDate, ShippingDate, Manager_Id, ShippingAddress_Id, PriceList_Id, Warehouse_Id, OrderStatus, Note) VALUES ({0}, {1}, '{2}', '{3}', {4}, {5}, {6}, {7}, {8}, '{9}')";
        protected override string GetSaveQueryFor(Order model)
        {
            return string.Format(SaveQueryTemplate,
                                 model.Id != 0 ? model.Id.ToString(CultureInfo.InvariantCulture) : "NULL",
                                 model.RoutePointId != 0 ? model.RoutePointId.ToString(CultureInfo.InvariantCulture) : "NULL",
                                 model.OrderDate.ToString("yyyy-MM-dd HH:mm:ss"),
                                 model.ShippingDate.ToString("yyyy-MM-dd HH:mm:ss"),
                                 model.ManagerId,
                                 model.ShippingAddressId,
                                 model.PriceListId,
                                 model.WarehouseId,
                                 model.OrderStatus,
                                 model.Note.Replace("'", "''"));
        }

        private const string DeleteQueryTemplate = "DELETE FROM Orders WHERE Id = {0}";
        protected override string GetDeleteQueryFor(Order model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
