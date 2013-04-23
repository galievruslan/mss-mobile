using System;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class RouteProxy : Route
    {
        internal void SetId(int id)
        {
            Id = id;
        }

        internal void SetDate(DateTime date)
        {
            Date = date;
        }
    }
}
