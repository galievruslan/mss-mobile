using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public interface IListPresenter<TViewModel> where TViewModel : ViewModel {
        int InitializeListSize();
        TViewModel GetItem(int index);
        void Select(int index);
        TViewModel SelectedModel { get; }
    }
}
