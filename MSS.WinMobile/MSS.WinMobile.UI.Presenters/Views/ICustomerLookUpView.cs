using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Presenters.Views
{
    public interface ICustomerLookUpView : IListView {
        CustomerViewModel SelectedCustomer { get; }
    }
}
