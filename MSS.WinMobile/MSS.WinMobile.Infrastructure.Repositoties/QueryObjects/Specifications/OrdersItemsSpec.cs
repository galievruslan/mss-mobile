using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications {
    public class OrdersItemsSpec : ISpecification<OrderItem> {

        public Order Order { get; private set; }
        public OrdersItemsSpec(Order order) {
            Order = order;
        }
    }
}
