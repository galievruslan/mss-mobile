using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class OrderItemQueryObject : QueryObject<OrderItem>
    {
        public OrderItemQueryObject(IStorage storage,
                                    ISpecificationTranslator<OrderItem> specificationTranslator,
                                    DataRecordTranslator<OrderItem> translator)
            : base(storage, specificationTranslator, translator) {}

        private const string SelectQuery =
            "SELECT orderItems.Id, orderItems.Order_Id, orderItems.Product_Id, products.Name as Product_Name, orderItems.Quantity " +
            "FROM OrderItems orderItems Left Join " +
            "Products products on orderItems.Product_Id = products.Id";
        protected override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
