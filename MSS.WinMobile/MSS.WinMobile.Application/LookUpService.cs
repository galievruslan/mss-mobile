using System.Collections.Generic;
using System.Windows.Forms;
using MSS.WinMobile.Resources;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views.LookUps;
using MSS.WinMobile.UI.Views.LookUps;

namespace MSS.WinMobile.Application {
    public class LookUpService : ILookUpService {
        private readonly IPresentersFactory _presentersFactory;
        private readonly ILocalizationManager _localizationManager;
        public LookUpService(IPresentersFactory presentersFactory, ILocalizationManager localizationManager) {
            _presentersFactory = presentersFactory;
            _localizationManager = localizationManager;
        }

        public CategoryViewModel LookUpCategory(CategoryViewModel currentCategory) {
            CategoryViewModel selectedCategory = null;
            using (var categoryLookUpView = new CategoryLookUpView(_presentersFactory, _localizationManager, currentCategory)) {
                if (categoryLookUpView.ShowDialog() == DialogResult.OK) {
                    selectedCategory = categoryLookUpView.SelectedCategory;
                }
            }

            return selectedCategory;
        }

        public CustomerViewModel LookUpCustomer() {
            CustomerViewModel selectedCustomer = null;
            using (var customerLookUpView = new CustomerLookUpView(_presentersFactory, _localizationManager)) {
                if (customerLookUpView.ShowDialog() == DialogResult.OK) {
                    selectedCustomer = customerLookUpView.SelectedCustomer;
                }
            }

            return selectedCustomer;
        }

        public ShippingAddressViewModel LookUpCustomerShippingAddress(CustomerViewModel customerViewModel) {
            ShippingAddressViewModel selectedShippingAddress = null;
            using (var shippingAddressLookUpView = new ShippingAddressLookUpView(_presentersFactory, _localizationManager, customerViewModel)) {
                if (shippingAddressLookUpView.ShowDialog() == DialogResult.OK) {
                    selectedShippingAddress = shippingAddressLookUpView.SelectedShippingAddress;
                }
            }

            return selectedShippingAddress;
        }

        public PriceListViewModel LookUpPriceList() {
            PriceListViewModel selectedPriceList = null;
            using (var priceListLookUpView = new PriceListLookUpView(_presentersFactory, _localizationManager)) {
                if (priceListLookUpView.ShowDialog() == DialogResult.OK) {
                    selectedPriceList = priceListLookUpView.SelectedPriceList;
                }
            }

            return selectedPriceList;
        }

        public WarehouseViewModel LookUpWarehouse() {
            WarehouseViewModel selectedWarehouse = null;
            using (var warehouseLookUpView = new WarehouseLookUpView(_presentersFactory, _localizationManager)) {
                if (warehouseLookUpView.ShowDialog() == DialogResult.OK) {
                    selectedWarehouse = warehouseLookUpView.SelectedWarehouse;
                }
            }

            return selectedWarehouse;
        }

        public IEnumerable<PickUpProductViewModel> PickUpProducts(PriceListViewModel priceListViewModel,
                                                                  IEnumerable<OrderItemViewModel> orderItems) {
            IEnumerable<PickUpProductViewModel> pickedUpProducts = null;
            using (var pickUpProductView = new PickUpProductView(_presentersFactory, _localizationManager, priceListViewModel, orderItems)) {
                if (pickUpProductView.ShowDialog() == DialogResult.OK) {
                    pickedUpProducts = pickUpProductView.PickedUpProducts;
                }
            }

            return pickedUpProducts;
        }
    }
}
