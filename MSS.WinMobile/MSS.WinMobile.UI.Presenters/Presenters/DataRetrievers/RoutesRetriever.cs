using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class RoutesRetriever : IDataPageRetriever<Route> {
        private readonly RouteRepository _routeRepository;
        public RoutesRetriever(RouteRepository routeRepository) {
            _routeRepository = routeRepository;
        }

        public int Count {
            get { return _routeRepository.Find().GetCount(); }
        }
        public Route[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage) {
            return
                _routeRepository.Find()
                                .OrderBy("Date", OrderDirection.Desceding)
                                .Page(lowerPageBoundary, rowsPerPage)
                                .ToArray();
        }
    }
}
