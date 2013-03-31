﻿using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class ShippingAddressRetriever : IDataPageRetriever<ShippingAddress>
    {
        private readonly Customer _customer;
        public ShippingAddressRetriever(Customer customer)
        {
            _customer = customer;
        }

        public int Count
        {
            get { return _customer.ShippingAddresses().Count(); }
        }

        public ShippingAddress[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            return
                _customer.ShippingAddresses()
                         .OrderBy(ShippingAddress.Table.Fields.ADDRESS, OrderDirection.Asceding)
                         .Page(lowerPageBoundary, rowsPerPage)
                         .ToArray();
        }
    }
}