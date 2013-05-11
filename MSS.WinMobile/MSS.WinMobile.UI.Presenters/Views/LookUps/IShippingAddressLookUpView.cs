using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Presenters.Views.LookUps
{
    public interface IShippingAddressLookUpView : IListView {
        ShippingAddressViewModel SelectedShippingAddress { get; }
    }
}
