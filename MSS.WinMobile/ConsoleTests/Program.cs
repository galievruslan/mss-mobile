using System;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Local.Data;
using MSS.WinMobile.Infrastructure.Local.Data.Repositories;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //string fullFilePath = string.Format(@"{0}\{1}",
            //                                    Path.GetDirectoryName(
            //                                        Assembly.GetExecutingAssembly()
            //                                              .GetName()
            //                                              .CodeBase),
            //                                    storageName);

            var session = new Session("testStorage.sdf");
            var repository = new GenericRepository<Customer>(session.GetConnection());
            //var c = new Customer
            //    {
            //        Id = 2,
            //        Name = "Second"
            //    };
            //repository.Add(c);


            var c = repository.GetById(1);
            repository.Delete(c);

            var ca = repository.Find();
            foreach (var customer in ca)
            {
                Console.WriteLine("{0}\t{1}", customer.Id, customer.Name);    
            }

            Console.Read();
        }
    }
}
