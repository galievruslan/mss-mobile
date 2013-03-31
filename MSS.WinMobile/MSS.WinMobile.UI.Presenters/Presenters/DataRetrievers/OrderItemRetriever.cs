using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class OrderItemRetriever : IDataPageRetriever<OrderItem>
    {
        private readonly Order _order;
        public OrderItemRetriever(Order order)
        {
            _order = order;
        }

        public int Count
        {
            get
            {
                return _order.Items().Count();
            }
        }

        public OrderItem[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            return
                _order.Items()
                         .OrderBy(Order.Table.Fields.ID, OrderDirection.Asceding)
                         .Page(lowerPageBoundary, rowsPerPage)
                         .ToArray();
        }
    }
}