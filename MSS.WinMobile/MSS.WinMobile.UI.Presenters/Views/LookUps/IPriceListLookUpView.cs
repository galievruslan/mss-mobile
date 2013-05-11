using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Presenters.Views.LookUps {
    public interface IPriceListLookUpView : IListView {
        PriceListViewModel SelectedPriceList { get; }
    }
}
