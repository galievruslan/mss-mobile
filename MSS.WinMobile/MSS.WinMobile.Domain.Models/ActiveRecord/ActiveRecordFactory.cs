using System;
using System.Collections.Generic;

namespace MSS.WinMobile.Domain.Models.ActiveRecord
{
    public static class ActiveRecordFactory
    {
        public static T Create<T>(IDictionary<string, object> dictionary) where T : ActiveRecordBase
        {
            T activeRecord;
            if (typeof (T) == typeof(Category))
            {
                activeRecord = new Category(dictionary) as T;
            }
            else if (typeof (T) == typeof (Customer))
            {
                activeRecord = new Customer(dictionary) as T;
            }
            else if (typeof(T) == typeof(Manager))
            {
                activeRecord = new Manager(dictionary) as T;
            }
            else if (typeof(T) == typeof(Order))
            {
                activeRecord = new Order(dictionary) as T;
            }
            else if (typeof(T) == typeof(OrderItem))
            {
                activeRecord = new OrderItem(dictionary) as T;
            }
            else if (typeof(T) == typeof(PriceList))
            {
                activeRecord = new PriceList(dictionary) as T;
            }
            else if (typeof(T) == typeof(Product))
            {
                activeRecord = new Product(dictionary) as T;
            }
            else if (typeof(T) == typeof(ProductsPrice))
            {
                activeRecord = new ProductsPrice(dictionary) as T;
            }
            else if (typeof(T) == typeof(ProductsUnitOfMeasure))
            {
                activeRecord = new ProductsUnitOfMeasure(dictionary) as T;
            }
            else if (typeof(T) == typeof(Route))
            {
                activeRecord = new Route(dictionary) as T;
            }
            else if (typeof(T) == typeof(RoutePoint))
            {
                activeRecord = new RoutePoint(dictionary) as T;
            }
            else if (typeof(T) == typeof(ShippingAddress))
            {
                activeRecord = new ShippingAddress(dictionary) as T;
            }
            else if (typeof(T) == typeof(Status))
            {
                activeRecord = new Status(dictionary) as T;
            }
            else if (typeof(T) == typeof(UnitOfMeasure))
            {
                activeRecord = new UnitOfMeasure(dictionary) as T;
            }
            else if (typeof(T) == typeof(Warehouse))
            {
                activeRecord = new Warehouse(dictionary) as T;
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
