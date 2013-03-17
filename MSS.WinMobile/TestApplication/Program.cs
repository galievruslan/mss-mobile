using System;
using System.Collections.Generic;
using System.Text;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ActiveRecordBase.Initialize(true);

            var customer = new Customer(1, "Some custoner");
            customer.Create();

            customer = new Customer(2, "Another custoner");
            customer.Create();

            customer = Customer.GetById(1);
            customer.Update();

            var c2 = Customer.GetById(1);

            Console.WriteLine(c2.Name);
        }
    }
}
