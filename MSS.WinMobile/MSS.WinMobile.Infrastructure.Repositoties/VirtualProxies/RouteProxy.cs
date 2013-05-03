﻿using System;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class RouteProxy : Route
    {
        public RouteProxy() {
        }

        public RouteProxy(DateTime date) : base(date) {
        }

        new public int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        new public DateTime Date
        {
            get { return base.Date; }
            set { base.Date = value; }
        }
    }
}
