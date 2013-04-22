using System;

namespace MSS.WinMobile.Domain.Models
{
    public class Route : Model
    {
        public Route(int id, int managetId, DateTime date)
            :base(id)
        {
            ManagerId = managetId;
            Date = date;
        }

        public int ManagerId { get; private set; }

        public DateTime Date { get; private set; }

        //public void AddPoint(ShippingAddress shippingAddress)
        //{
        //    // TODO Change retrieving status by id to retrieving by name in config
        //    var routePoint = new RoutePoint(this, shippingAddress, Status.GetById(2));
        //    routePoint.Save();
        //}
    }
}
