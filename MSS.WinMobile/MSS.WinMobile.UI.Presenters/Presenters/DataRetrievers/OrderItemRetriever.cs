using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class OrderItemRetriever : IDataPageRetriever<OrderItem> {
        private readonly Order _order;
        public OrderItemRetriever(Order order) {
            _order = order;
        }

        public int Count
        {
            get { return _order.Items.GetCount(); }
        }

        public OrderItem[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage) {
            return
                _order.Items.OrderBy("Id", OrderDirection.Asceding)
                      .Paged(lowerPageBoundary, rowsPerPage)
                      .ToArray();
        }
    }
}