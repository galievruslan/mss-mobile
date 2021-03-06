﻿using System.Collections.Generic;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Presenters.Views.LookUps {
    public interface ILookUpService {
        IEnumerable<CategoryViewModel> LookUpCategories(CategoryViewModel selectedCategoryViewModel);
        CustomerViewModel LookUpCustomer();
        ShippingAddressViewModel LookUpCustomerShippingAddress(CustomerViewModel customerViewModel);
        PriceListViewModel LookUpPriceList();
        WarehouseViewModel LookUpWarehouse();
        IEnumerable<PickUpProductViewModel> PickUpProducts(PriceListViewModel priceListViewModel, IEnumerable<OrderItemViewModel> orderItems);
    }
}
