using System;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public static class QueryObjectFactory
    {
        public static QueryObject<T> CreateQueryObject<T>() where T : ActiveRecordBase
        {
            string tableName;
            string[] fieldsNames;
            if (typeof(T) == typeof(Category))
            {
                tableName = Category.Table.TABLE_NAME;
                fieldsNames = new[]
                    {
                        Category.Table.Fields.ID, Category.Table.Fields.NAME,
                        Category.Table.Fields.PARENT_ID
                    };
            }
            else if (typeof(T) == typeof(Customer))
            {
                tableName = Customer.Table.TABLE_NAME;
                fieldsNames = new[]
                    {
                        Customer.Table.Fields.ID, Customer.Table.Fields.NAME
                    };
            }
            else if (typeof(T) == typeof(Manager))
            {
                tableName = Manager.Table.TABLE_NAME;
                fieldsNames = new[]
                    {
                        Manager.Table.Fields.ID, Manager.Table.Fields.NAME
                    };
            }
            else if (typeof(T) == typeof(Order))
            {
                return new OrderQueryObject() as QueryObject<T>;
            }
            else if (typeof(T) == typeof(OrderItem))
            {
                tableName = OrderItem.Table.TABLE_NAME;
                fieldsNames = new[]
                    {
                        OrderItem.Table.Fields.ID, OrderItem.Table.Fields.ORDER_ID,
                        OrderItem.Table.Fields.PRODUCT_ID, OrderItem.Table.Fields.QUANTITY
                    };
            }
            else if (typeof(T) == typeof(PriceList))
            {
                tableName = PriceList.Table.TABLE_NAME;
                fieldsNames = new[]
                    {
                        PriceList.Table.Fields.ID, Category.Table.Fields.NAME
                    };
            }
            else if (typeof(T) == typeof(Product))
            {
                tableName = Product.Table.TABLE_NAME;
                fieldsNames = new[]
                    {
                        Product.Table.Fields.ID, Product.Table.Fields.NAME,
                        Product.Table.Fields.CATEGORY_ID
                    };
            }
            else if (typeof(T) == typeof(ProductsPrice))
            {
                tableName = ProductsPrice.Table.TABLE_NAME;
                fieldsNames = new[]
                    {
                        ProductsPrice.Table.Fields.ID, ProductsPrice.Table.Fields.PRICE_LIST_ID,
                        ProductsPrice.Table.Fields.PRODUCT_ID, ProductsPrice.Table.Fields.VALUE
                    };
            }
            else if (typeof(T) == typeof(ProductsUnitOfMeasure))
            {
                tableName = ProductsUnitOfMeasure.Table.TABLE_NAME;
                fieldsNames = new[]
                    {
                        ProductsUnitOfMeasure.Table.Fields.ID, ProductsUnitOfMeasure.Table.Fields.PRODUCT_ID,
                        ProductsUnitOfMeasure.Table.Fields.UOM_ID, ProductsUnitOfMeasure.Table.Fields.BASE
                    };
            }
            else if (typeof(T) == typeof(Route))
            {
                tableName = Route.Table.TABLE_NAME;
                fieldsNames = new[]
                    {
                        Route.Table.Fields.ID, Route.Table.Fields.DATE,
                        Route.Table.Fields.MANAGER_ID
                    };
            }
            else if (typeof(T) == typeof(RoutePoint))
            {
                tableName = RoutePoint.Table.TABLE_NAME;
                fieldsNames = new[]
                    {
                        RoutePoint.Table.Fields.ID, RoutePoint.Table.Fields.ROUTE_ID,
                        RoutePoint.Table.Fields.ORDER_ID, RoutePoint.Table.Fields.SHIPPING_ADDRESS_ID,
                        RoutePoint.Table.Fields.STATUS_ID
                    };
            }
            else if (typeof(T) == typeof(RouteTemplate))
            {
                tableName = RouteTemplate.Table.TABLE_NAME;
                fieldsNames = new[]
                    {
                        RouteTemplate.Table.Fields.ID, RouteTemplate.Table.Fields.DAY_OF_WEEK,
                        RouteTemplate.Table.Fields.MANAGER_ID
                    };
            }
            else if (typeof(T) == typeof(RoutePointTemplate))
            {
                tableName = RoutePointTemplate.Table.TABLE_NAME;
                fieldsNames = new[]
                    {
                        RoutePointTemplate.Table.Fields.ID, RoutePointTemplate.Table.Fields.ROUTE_TEMPLATE_ID,
                        RoutePointTemplate.Table.Fields.SHIPPING_ADDRESS_ID
                    };
            }
            else if (typeof(T) == typeof(ShippingAddress))
            {
                tableName = ShippingAddress.Table.TABLE_NAME;
                fieldsNames = new[]
                    {
                        ShippingAddress.Table.Fields.ID, ShippingAddress.Table.Fields.NAME,
                        ShippingAddress.Table.Fields.ADDRESS, ShippingAddress.Table.Fields.CUSTOMER_ID
                    };
            }
            else if (typeof(T) == typeof(Status))
            {
                tableName = Status.Table.TABLE_NAME;
                fieldsNames = new[]
                    {
                        Status.Table.Fields.ID, Status.Table.Fields.NAME
                    };
            }
            else if (typeof(T) == typeof(UnitOfMeasure))
            {
                tableName = UnitOfMeasure.Table.TABLE_NAME;
                fieldsNames = new[]
                    {
                        UnitOfMeasure.Table.Fields.ID, UnitOfMeasure.Table.Fields.NAME
                    };
            }
            else if (typeof(T) == typeof(Warehouse))
            {
                tableName = Warehouse.Table.TABLE_NAME;
                fieldsNames = new[]
                    {
                        Warehouse.Table.Fields.ID, Warehouse.Table.Fields.ADDRESS
                    };
            }
            else
            {
                throw new InvalidOperationException(string.Format("Can't create query object for type {0}.",
                                                                  typeof(T)));
            }

            return new QueryObject<T>(tableName, fieldsNames);
        }
    }
}
