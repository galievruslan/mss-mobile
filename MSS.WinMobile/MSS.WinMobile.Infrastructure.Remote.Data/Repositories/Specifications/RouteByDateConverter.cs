using System;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Specifications;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;

namespace MSS.WinMobile.Infrastructure.Remote.Data.Repositories.Specifications
{
    public class RouteByDateConverter : Converter<Route> {
        public RouteByDateConverter(Specification<Route> specification) : base(specification) {
        }

        public override string Convert() {
            var routeByDateSpecification = Specification as RouteByDateSpecification;

            string result = string.Empty;
            if (routeByDateSpecification != null) {
                result = string.Format(@"date={0}", Uri.EscapeDataString(routeByDateSpecification.Date.ToShortDateString()));
            }

            return result;
        }
    }
}
