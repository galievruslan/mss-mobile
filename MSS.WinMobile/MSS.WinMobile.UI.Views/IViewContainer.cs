using System;
using MSS.WinMobile.UI.Views.Views;

namespace MSS.WinMobile.UI.Views {
    public interface IViewContainer : IDisposable {
        void SetView(View view);
        void Close();

        void ShowInformation(string message);
        void ShowError(string message);
        bool ShowConfirmation(string message);
        void ShowDetails(string details);

        void RegisterLeftAction(IViewAction viewAction);
        void RegisterRightAction(IViewAction viewAction);
    }
}
