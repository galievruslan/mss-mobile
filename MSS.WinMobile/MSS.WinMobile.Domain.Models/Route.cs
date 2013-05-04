using System;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Domain.Models
{
    public abstract class Route : Model
    {
        protected Route() {
        }

        protected Route(DateTime date) {
            Date = date;
        }

        public DateTime Date { get; protected set; }

        public abstract IQueryObject<RoutePoint> Points { get; }
    }
}
