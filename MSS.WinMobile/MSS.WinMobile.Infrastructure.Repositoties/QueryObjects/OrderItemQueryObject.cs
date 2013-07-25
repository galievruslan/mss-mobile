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
            "SELECT orderItems.Id, orderItems.Order_Id, orderItems.Product_Id, orderItems.UnitOfMeasure_Id, orderItems.Count_In_Base_UnitOfMeasure, products.Name as Product_Name, orderItems.Quantity, orderItems.Price, orderItems.Amount, uom.Name as UnitOfMeasure_Name " +
            "FROM OrderItems orderItems Left Join " +
            "Products products on orderItems.Product_Id = products.Id Left Join " +
            "UnitsOfMeasure uom on orderItems.UnitOfMeasure_Id = uom.Id";            
        protected override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
