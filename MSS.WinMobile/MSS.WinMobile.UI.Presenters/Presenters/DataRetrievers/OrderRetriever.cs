using System;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;
using MSS.WinMobile.UI.Presenters.Presenters.Specifications;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class OrderRetriever : IDataPageRetriever<Order> {
        private readonly IStorageRepository<Order> _orderRepository;
        private readonly ISpecification<Order> _orderOnDateSpec;
        public OrderRetriever(IStorageRepository<Order> orderRepository, DateTime date) {
            _orderRepository = orderRepository;
            _orderOnDateSpec = new OrdersOnDateSpec(date);
        }

        public int Count
        {
            get {
                return _orderRepository.Find().Where(_orderOnDateSpec).Count();
            }
        }

        public Order[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage) {
            return
                _orderRepository.Find().Where(_orderOnDateSpec).OrderBy("Id", OrderDirection.Asceding)
                                .Paged(lowerPageBoundary, rowsPerPage)
                                .ToArray();
        }
    }
}