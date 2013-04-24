using System;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class RouteTemplateProxy : RouteTemplate
    {
        new public int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        new public DayOfWeek DayOfWeek
        {
            get { return base.DayOfWeek; }
            set { base.DayOfWeek = value; }
        }
    }
}