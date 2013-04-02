using System;

namespace MSS.WinMobile.UI.Presenters.Views
{
    public interface IView : IDisposable
    {
        void ShowView();
        DialogViewResult ShowDialogView();

        void CloseView();

        void DisplayErrors(string error);
    }

    public enum DialogViewResult
    {
        OK,
        Cancel
    }
}
