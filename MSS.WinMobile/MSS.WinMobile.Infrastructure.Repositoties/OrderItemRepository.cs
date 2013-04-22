using System.Globalization;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class OrderItemRepository : Repository<OrderItem>
    {
        public OrderItemRepository(SQLiteConnectionFactory connectionFactory, SQLiteUnitOfWork unitOfWork)
            : base(connectionFactory, unitOfWork)
        {
        }

        protected override QueryObject<OrderItem> GetQueryObject()
        {
            return new OrderItemQueryObject(ConnectionFactory, new OrderItemTranslator());
        }

        private const string SaveQueryTemplate =
            "INSERT OR REPLACE INTO OrderItems (Id, Order_Id, Product_Id, Quantity) VALUES ({0}, {1}, {2}, {3})";
        protected override string GetSaveQueryFor(OrderItem model)
        {
            return string.Format(SaveQueryTemplate,
                                 model.Id != 0 ? model.Id.ToString(CultureInfo.InvariantCulture) : "NULL",
                                 model.OrderId,
                                 model.ProductId,
                                 model.Quantity);
        }

        private const string DeleteQueryTemplate = "DELETE FROM OrderItems WHERE Id = {0}";
        protected override string GetDeleteQueryFor(OrderItem model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
