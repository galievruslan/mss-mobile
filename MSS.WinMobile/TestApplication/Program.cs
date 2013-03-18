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
        static void Main(string[] args)
        {
            ActiveRecordBase.Initialize(true);

            for (int i = 1; i < 101; i++)
            {
                var newCustomer = new Customer(i, "Customer #" + i.ToString(CultureInfo.InvariantCulture));
                newCustomer.Create();
            }

            var customer = Customer.GetById(15);

            var customers = Customer.GetAll().ToArray();
            customers = Customer.GetAll().Where(Customer.Table.Fields.NAME, new Contains("66")).ToArray();
            customers = Customer.GetAll().OrderBy(Customer.Table.Fields.NAME, OrderDirection.Asceding).ToArray();
            customers = Customer.GetAll().OrderBy(Customer.Table.Fields.ID, OrderDirection.Asceding).Skip(30).ToArray();
            customers = Customer.GetAll().OrderBy(Customer.Table.Fields.ID, OrderDirection.Asceding).Skip(30).Take(10).ToArray();


            var c2 = Customer.GetById(1);

            Console.WriteLine(c2.Name);
        }
    }
}
