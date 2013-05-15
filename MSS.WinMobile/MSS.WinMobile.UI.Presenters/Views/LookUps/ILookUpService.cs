using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Presenters.Views.LookUps {
    public interface ILookUpService {
        CustomerViewModel LookUpCustomer();
        ShippingAddressViewModel LookUpCustomerShippingAddress(CustomerViewModel customerViewModel);
    }
}
