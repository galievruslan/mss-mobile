using System;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Domain.Models
{
    public abstract class RouteTemplate : Model
    {
        public DayOfWeek DayOfWeek { get; protected set; }

        public abstract IQueryObject<RoutePointTemplate> PointTemplates { get; }
    }
}
