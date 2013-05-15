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
    }
}
