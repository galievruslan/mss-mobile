using System;
using System.Linq;
using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;

namespace MSS.WinMobile.Domain.Specifications
{
    public class RouteByDateSpecification : Specification<Route> {
        public RouteByDateSpecification(DateTime date) {
            Date = date.Date;
        }

        public DateTime Date { get; private set; }

        public override bool IsSatisfiedBy(Route entity) {
            return entity.Date.Date.Equals(Date);
        }

        public override IEnumerable<Route> GetSatisfied(IEnumerable<Route> entities) {
            return entities.Where(IsSatisfiedBy);
        }
    }
}
