using System;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.UI.Presenters.Presenters.Specifications {
    public class OrdersOnDateSpec : ISpecification<Order> {
        public DateTime Date { get; private set; }

        public OrdersOnDateSpec(DateTime date) {
            Date = date.Date;
        }
    }
}
