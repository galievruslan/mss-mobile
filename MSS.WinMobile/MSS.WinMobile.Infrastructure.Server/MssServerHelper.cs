using System;
using System.Collections.Generic;
using System.Text;
using Mss.WinMobile.Domain.Model;

namespace MSS.WinMobile.Infrastructure.Server
{
    public static class MssServerHelper
    {
        public static string GetControllerName(Type type)
        {
            string controllerName = string.Empty;
            if (type.Equals(typeof(Manager)))
            {
                controllerName = "managers";
            } else if (type.Equals(typeof(Customer)))
            {
                controllerName = "customers";
            } else if (type.Equals(typeof(Order)))
            {
                controllerName = "orders";
            } else if (type.Equals(typeof(OrderItem)))
            {
                controllerName = "order_items";
            } else if (type.Equals(typeof(Product)))
            {
                controllerName = "products";
            } else if (type.Equals(typeof(Route)))
            {
                controllerName = "routes";
            } else if (type.Equals(typeof(RoutePoint)))
            {
                controllerName = "route_points";
            } else if (type.Equals(typeof(Status)))
            {
                controllerName = "statuses";
            } 
            else 
            {
                throw new ControllerForTypeNotFoundException(type);
            }

            return controllerName;
        }

        public class ControllerForTypeNotFoundException : Exception
        {
            public ControllerForTypeNotFoundException(Type type)
                : base(string.Format(@"Controller for type ""{0}"" not found", type)) { }
        }
    }
}
