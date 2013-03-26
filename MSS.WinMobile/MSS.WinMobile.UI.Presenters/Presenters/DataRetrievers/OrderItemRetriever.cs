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

        private int _cachedCount;
        public int Count
        {
            get
            {
                if (_cachedCount == 0)
                    _cachedCount = _order.Items().Count();
                return _cachedCount;
            }
        }

        public OrderItem[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            return
                _order.Items()
                         .OrderBy(Order.Table.Fields.ID, OrderDirection.Asceding)
                         .Skip(lowerPageBoundary)
                         .Take(rowsPerPage)
                         .ToArray();
        }
    }
}