﻿using System.Data.SQLite;
using System.Globalization;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class OrderStorageRepository : SqLiteStorageRepository<Order> {
        private readonly ISpecificationTranslator<Order> _specificationTranslator;
        private readonly IRepositoryFactory _repositoryFactory;
        internal OrderStorageRepository(IStorage storage, ISpecificationTranslator<Order> specificationTranslator, IRepositoryFactory repositoryFactory)
            : base(storage) {
            _specificationTranslator = specificationTranslator;
            _repositoryFactory = repositoryFactory;
        }

        protected override QueryObject<Order> GetQueryObject()
        {
            return new OrderQueryObject(Storage, _specificationTranslator, new OrderDataRecordTranslator(_repositoryFactory));
        }

        private const string SaveQueryTemplate =
            "INSERT OR REPLACE INTO Orders (Id, RoutePoint_Id, OrderDate, ShippingDate, ShippingAddress_Id, PriceList_Id, Warehouse_Id, OrderStatus, Note) VALUES ({0}, {1}, '{2}', '{3}', {4}, {5}, {6}, {7}, '{8}')";
        protected override string GetSaveQueryFor(Order model)
        {
            return string.Format(SaveQueryTemplate,
                                 model.Id != 0 ? model.Id.ToString(CultureInfo.InvariantCulture) : "NULL",
                                 model.RoutePointId != 0 ? model.RoutePointId.ToString(CultureInfo.InvariantCulture) : "NULL",
                                 model.OrderDate.ToString("yyyy-MM-dd HH:mm:ss"),
                                 model.ShippingDate.ToString("yyyy-MM-dd HH:mm:ss"),
                                 model.ShippingAddressId,
                                 model.PriceListId,
                                 model.WarehouseId,
                                 (int)model.OrderStatus,
                                 model.Note.Replace("'", "''"));
        }

        private const string DeleteQueryTemplate = "DELETE FROM Orders WHERE Id = {0}";
        protected override string GetDeleteQueryFor(Order model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
