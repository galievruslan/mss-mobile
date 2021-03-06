﻿using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Domain.Models
{
    public abstract class RoutePoint : Model
    {
        protected RoutePoint() {
            
        }

        protected RoutePoint(Route route) {
            RouteId = route.Id;
        }

        public int RouteId { get; protected set; }

        public int ShippingAddressId { get; protected set; }
        public string ShippingAddressName { get; protected set; }
        public string ShippingAddressAddress { get; protected set; }

        public int StatusId { get; protected set; }
        public string StatusName { get; protected set; }

        public void SetShippingAddress(ShippingAddress shippingAddress) {
            ShippingAddressId = shippingAddress.Id;
            ShippingAddressName = shippingAddress.Name;
            ShippingAddressAddress = shippingAddress.Address;
        }

        public void SetStatus(Status status) {
            StatusId = status.Id;
            StatusName = status.Name;
        }

        public bool Synchronized { get; set; }

        public abstract IQueryObject<Order> Orders { get; }

        public abstract Order CreateOrder();
    }
}
