using System;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class RouteTemplateProxy : RouteTemplate
    {
        internal void SetId(int id)
        {
            Id = id;
        }

        internal void SetRouteTemplateId(DayOfWeek dayOfWeek)
        {
            DayOfWeek = dayOfWeek;
        }
    }
}