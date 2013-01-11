using System;
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

        public override Route[] GetSatisfied(Route[] entities) {
            var satisfyed = new List<Route>();
            for (int i = 0; i < entities.Length; i++)
            {
                if (IsSatisfiedBy(entities[i]))
                    satisfyed.Add(entities[i]);
            }

            return satisfyed.ToArray();
        }
    }
}
