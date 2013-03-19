using System;
using System.Globalization;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace TestApplication
{
    class Program
    {
        static void Main()
        {
            ActiveRecordBase.Initialize(true);

            //for (int i = 1; i < 101; i++)
            //{
            //    var newCustomer = new Customer(i, "Customer #" + i.ToString(CultureInfo.InvariantCulture));
            //    newCustomer.Create();
            //}

            //var customer = Customer.GetById(15);

            //var customers = Customer.GetAll().ToArray();
            //customers = Customer.GetAll().Where(Customer.Table.Fields.NAME, new Contains("66")).ToArray();
            //customers = Customer.GetAll().OrderBy(Customer.Table.Fields.NAME, OrderDirection.Asceding).ToArray();
            //customers = Customer.GetAll().OrderBy(Customer.Table.Fields.ID, OrderDirection.Asceding).Skip(30).ToArray();
            //customers = Customer.GetAll().OrderBy(Customer.Table.Fields.ID, OrderDirection.Asceding).Skip(30).Take(10).ToArray();


            //var c2 = Customer.GetById(1);

            //Console.WriteLine(c2.Name);

            ActiveRecordBase.BeginTransaction();
            var status = new Status(1, "New");
            status.Create();
            var manager = new Manager(1, "Manager");
            manager.Create();
            var route = new Route(1, manager.Id, DateTime.Today);
            route.Create();
            var customer = new Customer(1, "Customer");
            customer.Create();
            var shippingAddress1 = new ShippingAddress(1, customer.Id, "FirstAddress", "Address 1");
            shippingAddress1.Create();
            var shippingAddress2 = new ShippingAddress(2, customer.Id, "SecondAddress", "Address 2");
            shippingAddress2.Create();
            var routePoint1 = new RoutePoint(1, route.Id, shippingAddress1.Id, status.Id);
            routePoint1.Create();
            var routePoint2 = new RoutePoint(2, route.Id, shippingAddress2.Id, status.Id);
            routePoint2.Create();
            ActiveRecordBase.Commit();

            var routePoints = route.GetPoints().ToArray();
            Console.ReadLine();
        }
    }
}
