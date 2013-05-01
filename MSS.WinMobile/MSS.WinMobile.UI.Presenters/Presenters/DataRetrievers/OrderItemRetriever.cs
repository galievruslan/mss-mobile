using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects.Conditions;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class OrderItemRetriever : IDataPageRetriever<OrderItem> {
        private readonly OrderItemRepository _orderItemRepository;
        private readonly Order _order;
        public OrderItemRetriever(OrderItemRepository orderItemRepository, Order order) {
            _orderItemRepository = orderItemRepository;
            _order = order;
        }

        public int Count
        {
            get { return _orderItemRepository.Find().Where("Order_Id", new Equals(_order.Id)).GetCount(); }
        }

        public OrderItem[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            return
                _orderItemRepository.Find().Where("Order_Id", new Equals(_order.Id))
                         .OrderBy("Id", OrderDirection.Asceding)
                         .Page(lowerPageBoundary, rowsPerPage)
                         .ToArray();
        }
    }
}