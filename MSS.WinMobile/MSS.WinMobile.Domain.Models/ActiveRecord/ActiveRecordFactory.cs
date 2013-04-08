using System;
using System.Data;

namespace MSS.WinMobile.Domain.Models.ActiveRecord
{
    public static class ActiveRecordFactory
    {
        public static T Create<T>(IDataRecord dataRecord) where T : ActiveRecordBase
        {
            T activeRecord;
            if (typeof (T) == typeof(Category))
            {
                activeRecord = new Category(dataRecord, string.Empty) as T;
            }
            else if (typeof (T) == typeof (Customer))
            {
                activeRecord = new Customer(dataRecord, string.Empty) as T;
            }
            else if (typeof(T) == typeof(Manager))
            {
                activeRecord = new Manager(dataRecord, string.Empty) as T;
            }
            else if (typeof(T) == typeof(Order))
            {
                activeRecord = new Order(dataRecord, string.Empty) as T;
            }
            else if (typeof(T) == typeof(OrderItem))
            {
                activeRecord = new OrderItem(dataRecord, string.Empty) as T;
            }
            else if (typeof(T) == typeof(PriceList))
            {
                activeRecord = new PriceList(dataRecord, string.Empty) as T;
            }
            else if (typeof(T) == typeof(Product))
            {
                activeRecord = new Product(dataRecord, string.Empty) as T;
            }
            else if (typeof(T) == typeof(ProductsPrice))
            {
                activeRecord = new ProductsPrice(dataRecord, string.Empty) as T;
            }
            else if (typeof(T) == typeof(ProductsUnitOfMeasure))
            {
                activeRecord = new ProductsUnitOfMeasure(dataRecord, string.Empty) as T;
            }
            else if (typeof(T) == typeof(Route))
            {
                activeRecord = new Route(dataRecord, string.Empty) as T;
            }
            else if (typeof(T) == typeof(RoutePoint))
            {
                activeRecord = new RoutePoint(dataRecord, string.Empty) as T;
            }
            else if (typeof(T) == typeof(RouteTemplate))
            {
                activeRecord = new RouteTemplate(dataRecord, string.Empty) as T;
            }
            else if (typeof(T) == typeof(RoutePointTemplate))
            {
                activeRecord = new RoutePointTemplate(dataRecord, string.Empty) as T;
            }
            else if (typeof(T) == typeof(ShippingAddress))
            {
                activeRecord = new ShippingAddress(dataRecord, string.Empty) as T;
            }
            else if (typeof(T) == typeof(Status))
            {
                activeRecord = new Status(dataRecord, string.Empty) as T;
            }
            else if (typeof(T) == typeof(UnitOfMeasure))
            {
                activeRecord = new UnitOfMeasure(dataRecord, string.Empty) as T;
            }
            else if (typeof(T) == typeof(Warehouse))
            {
                activeRecord = new Warehouse(dataRecord, string.Empty) as T;
            }
            else
            {
                throw new InvalidOperationException(string.Format("Can't create object of type {0} from dictionary.",
                                                                  typeof (T)));
            }

            return activeRecord;
        }
    }
}
