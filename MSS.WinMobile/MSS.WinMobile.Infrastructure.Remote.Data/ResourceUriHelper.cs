using System;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.Remote.Data
{
    public static class ResourceUriHelper
    {
        public static string GetControllerName(Type type)
        {
            string controllerName;
            if (type == typeof(Manager))
            {
                controllerName = "managers";
            } else if (type == typeof(Customer))
            {
                controllerName = "customers";
            } else if (type == typeof(Order))
            {
                controllerName = "orders";
            } else if (type == typeof(OrderItem))
            {
                controllerName = "order_items";
            } else if (type == typeof(Product))
            {
                controllerName = "products";
            } else if (type == typeof(Route))
            {
                controllerName = "routes";
            } else if (type == typeof(RoutePoint))
            {
                controllerName = "route_points";
            } else if (type == typeof(Status))
            {
                controllerName = "statuses";
            }
            else if (type == typeof(Warehouse))
            {
                controllerName = "warehouses";
            }
            else if (type == typeof(UnitOfMeasure))
            {
                controllerName = "unit_of_measures";
            }
            else if (type == typeof(PriceList))
            {
                controllerName = "price_lists";
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
