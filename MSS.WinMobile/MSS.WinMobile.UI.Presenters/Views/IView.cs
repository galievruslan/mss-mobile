using System;

namespace MSS.WinMobile.UI.Presenters.Views
{
    public interface IView : IDisposable {
        void ShowInformation(string message);
        void ShowError(string message);
        bool ShowConfirmation(string message);
    }
}
