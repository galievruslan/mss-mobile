using System.Collections.Generic;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views.LookUps;
using MSS.WinMobile.UI.Views.LookUps;
using OpenNETCF.Windows.Forms;

namespace MSS.WinMobile.Application {
    public class LookUpService : ILookUpService {
        private readonly IPresentersFactory _presentersFactory;
        public LookUpService(IPresentersFactory presentersFactory) {
            _presentersFactory = presentersFactory;
        }

        public CategoryViewModel LookUpCategory(CategoryViewModel currentCategory) {
            CategoryViewModel selectedCategory = null;
            using (var categoryLookUpView = new CategoryLookUpView(_presentersFactory, currentCategory)) {
                if (Application2.ShowDialog(categoryLookUpView) == DialogResult.OK) {
                    selectedCategory = categoryLookUpView.SelectedCategory;
                }
            }

            return selectedCategory;
        }

        public CustomerViewModel LookUpCustomer() {
            CustomerViewModel selectedCustomer = null;
            using (var customerLookUpView = new CustomerLookUpView(_presentersFactory)) {
                if (Application2.ShowDialog(customerLookUpView) == DialogResult.OK) {
                    selectedCustomer = customerLookUpView.SelectedCustomer;
                }
            }

            return selectedCustomer;
        }

        public ShippingAddressViewModel LookUpCustomerShippingAddress(CustomerViewModel customerViewModel) {
            ShippingAddressViewModel selectedShippingAddress = null;
            using (var shippingAddressLookUpView = new ShippingAddressLookUpView(_presentersFactory, customerViewModel)) {
                if (Application2.ShowDialog(shippingAddressLookUpView) == DialogResult.OK) {
                    selectedShippingAddress = shippingAddressLookUpView.SelectedShippingAddress;
                }
            }

            return selectedShippingAddress;
        }

        public PriceListViewModel LookUpPriceList() {
            PriceListViewModel selectedPriceList = null;
            using (var priceListLookUpView = new PriceListLookUpView(_presentersFactory)) {
                if (Application2.ShowDialog(priceListLookUpView) == DialogResult.OK) {
                    selectedPriceList = priceListLookUpView.SelectedPriceList;
                }
            }

            return selectedPriceList;
        }

        public WarehouseViewModel LookUpWarehouse() {
            WarehouseViewModel selectedWarehouse = null;
            using (var warehouseLookUpView = new WarehouseLookUpView(_presentersFactory)) {
                if (Application2.ShowDialog(warehouseLookUpView) == DialogResult.OK) {
                    selectedWarehouse = warehouseLookUpView.SelectedWarehouse;
                }
            }

            return selectedWarehouse;
        }

        public IEnumerable<PickUpProductViewModel> PickUpProducts(PriceListViewModel priceListViewModel, IEnumerable<OrderItemViewModel> orderItems) {
            IEnumerable<PickUpProductViewModel> pickedUpProducts = null;
            using (var pickUpProductView = new PickUpProductView(_presentersFactory, priceListViewModel, orderItems)) {
                if (Application2.ShowDialog(pickUpProductView) == DialogResult.OK) {
                    pickedUpProducts = pickUpProductView.PickedUpProducts;
                }
            }

            return pickedUpProducts;
        }
    }
}
