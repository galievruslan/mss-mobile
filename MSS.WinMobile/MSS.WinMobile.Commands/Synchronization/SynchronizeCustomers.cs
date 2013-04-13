using System;
using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Infrastructure.Server;
using Customer = MSS.WinMobile.Domain.Models.Customer;
using MSS.WinMobile.Common.Observable;

namespace MSS.WinMobile.Commands.Synchronization
{
    public class SynchronizeCustomers : Command<bool>
    {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(SynchronizeCustomers));

        private readonly Server _server;

        public SynchronizeCustomers(Server server) {
            _server = server;
        }

        protected override bool Execute() {
            var customers = new List<Customer>();
            var shippingAddresses = new List<ShippingAddress>();

            int pageNumber = 1;
            const int itemsPerPage = 100;
            var customersDtos = _server.CustomerService.GetCustomers(pageNumber, itemsPerPage);
            while (customersDtos.Length > 0)
            {
                Notificate(
                    new TextNotification(string.Format("Synchronize Customers from {0} to {1}.",
                                       (pageNumber - 1) * itemsPerPage,
                                       (pageNumber - 1) * itemsPerPage + itemsPerPage)));

                foreach (var customerDto in customersDtos)
                {
                    var customer = new Customer(customerDto.Id, customerDto.Name);
                    customers.Add(customer);

                    foreach (var shippingAddressDto in customerDto.ShippingAddresses)
                    {
                        var shippingAddress = new ShippingAddress(shippingAddressDto.Id, customerDto.Id,
                                                                  shippingAddressDto.Name, shippingAddressDto.Address);
                        shippingAddresses.Add(shippingAddress);
                    }
                }

                if (customers.Any())
                {
                    ActiveRecordBase.BeginTransaction();
                    try
                    {
                        foreach (var customer in customers) {
                            customer.Save();
                        }
                        ActiveRecordBase.Commit();
                    }
                    catch (Exception)
                    {
                        ActiveRecordBase.Rollback();
                    }
                }

                if (shippingAddresses.Any())
                {
                    ActiveRecordBase.BeginTransaction();
                    try
                    {
                        foreach (var shippingAddress in shippingAddresses) {
                            shippingAddress.Save();
                        }
                        ActiveRecordBase.Commit();
                    }
                    catch (Exception exception)
                    {
                        ActiveRecordBase.Rollback();
                    }
                }

                customers.Clear();
                shippingAddresses.Clear();

                pageNumber++;
                customersDtos = _server.CustomerService.GetCustomers(pageNumber, itemsPerPage);
            }

            return true;
        }
    }
}
