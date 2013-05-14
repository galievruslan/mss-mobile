using System.Globalization;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class OrderItemStorageRepository : SqLiteStorageRepository<OrderItem> {
        private readonly ISpecificationTranslator<OrderItem> _specificationTranslator;
        internal OrderItemStorageRepository(IStorage storage, ISpecificationTranslator<OrderItem> specificationTranslator)
            : base(storage) {
            _specificationTranslator = specificationTranslator;
        }

        protected override QueryObject<OrderItem> GetQueryObject()
        {
            return new OrderItemQueryObject(Storage, _specificationTranslator, new OrderItemDataRecordTranslator());
        }

        private static readonly NumberFormatInfo DecimalFormat = NumberFormatInfo.InvariantInfo;
        private const string SaveQueryTemplate =
            "INSERT OR REPLACE INTO OrderItems (Id, Order_Id, Product_Id, UnitOfMeasure_Id, Quantity, Price) VALUES ({0}, {1}, {2}, {3}, {4}, {5})";
        protected override string GetSaveQueryFor(OrderItem model)
        {
            return string.Format(SaveQueryTemplate,
                                 model.Id != 0 ? model.Id.ToString(CultureInfo.InvariantCulture) : "NULL",
                                 model.OrderId,
                                 model.ProductId,
                                 model.UnitOfMeasureId,
                                 model.Quantity,
                                 model.Price.ToString(DecimalFormat));
        }

        private const string DeleteQueryTemplate = "DELETE FROM OrderItems WHERE Id = {0}";
        protected override string GetDeleteQueryFor(OrderItem model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
