using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Server;
using Customer = MSS.WinMobile.Domain.Models.Customer;

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
                foreach (var customerDto in customersDtos)
                {
                    var customer = new Customer
                    {
                        Id = customerDto.Id,
                        Name = customerDto.Name
                    };
                    customers.Add(customer);

                    foreach (var shippingAddressDto in customerDto.ShippingAddresses)
                    {
                        var shippingAddress = new ShippingAddress
                        {
                            Id = shippingAddressDto.Id,
                            Name = shippingAddressDto.Name,
                            Address = shippingAddressDto.Address,
                            CustomerId = customerDto.Id
                        };
                        shippingAddresses.Add(shippingAddress);
                    }
                }

                //SynchronizeEntity(customers);
                //SynchronizeEntity(shippingAddresses);
                customers.Clear();
                shippingAddresses.Clear();

                pageNumber++;
                customersDtos = _server.CustomerService.GetCustomers(pageNumber, itemsPerPage);
            }

            return true;
        }
    }
}
