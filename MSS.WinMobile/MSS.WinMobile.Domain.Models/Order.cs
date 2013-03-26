using System;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Order
    {
        public Order(RoutePoint routePoint)
        {
            Date = DateTime.Now;
            Manager = routePoint.Route.Manager;
            ShippingAddress = routePoint.ShippingAddress;
            Customer = ShippingAddress.Customer;
        }

        public DateTime Date { get; private set; }

        private Customer _customer;
        public Customer Customer
        {
            get { return _customer ?? (_customer = ShippingAddress.Customer); }
            private set { _customer = value; }
        }

        public void SetCustomer(Customer customer)
        {
            if (!Customer.Equals(customer))
            {
                _customer = customer;
                if (ShippingAddress != null)
                {
                    if (_customer.ShippingAddresses().All(address => !address.Equals(ShippingAddress)))
                    {
                        ShippingAddress = null;
                    }
                }
            }
        }

        public ShippingAddress ShippingAddress { get; private set; }

        public void SetShippingAddress(ShippingAddress shippingAddress)
        {
            ShippingAddress = shippingAddress;
        }

        public Manager Manager { get; private set; }

        public PriceList PriceList { get; private set; }

        public void SetPriceList(PriceList priceList)
        {
            PriceList = priceList;
        }

        public Warehouse Warehouse { get; private set; }

        public void SetWarehouse(Warehouse warehouse)
        {
            Warehouse = warehouse;
        }

        public string Note { get; set; }

        public QueryObject<OrderItem> Items()
        {
            return OrderItem.GetByOrder(this);
        }
    }
}
