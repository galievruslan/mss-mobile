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

            var customer = new Customer
                {
                    Id = 1,
                    Name = "Some custoner"
                };

            customer.Create();

            customer = new Customer
            {
                Id = 2,
                Name = "Another custoner"
            };
            customer.Create();

            customer = Customer.GetById(1);
            customer.Name = "Changed Name";
            customer.Update();

            var c2 = Customer.GetById(1);

            Console.WriteLine(c2.Name);
        }
    }
}
