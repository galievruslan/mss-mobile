using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public interface IPresenter<TViewModel> {
        TViewModel Initialize();
    }
}
