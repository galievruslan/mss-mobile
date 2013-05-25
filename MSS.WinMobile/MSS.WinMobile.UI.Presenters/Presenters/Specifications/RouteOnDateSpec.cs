using System;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.UI.Presenters.Presenters.Specifications {
    public class RouteOnDateSpec : ISpecification<Route> {
        public DateTime Date { get; private set; }
        public RouteOnDateSpec(DateTime date) {
            Date = date.Date;
        }
    }
}
