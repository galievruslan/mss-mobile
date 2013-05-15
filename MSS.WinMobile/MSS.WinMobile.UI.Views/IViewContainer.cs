using System;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views {
    public interface IViewContainer : IDisposable {
        void SetView(IView view);
        void Close();
    }
}
