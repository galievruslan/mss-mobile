using System;
using System.Collections.Generic;
using MSS.WinMobile.UI.Views.Views;

namespace MSS.WinMobile.UI.Views {
    public interface IViewContainer : IDisposable {
        void SetView(View view);
        void Close();

        void ShowInformation(string message);
        void ShowError(IEnumerable<string> messages);
        bool ShowConfirmation(string message);
        void ShowDetails(IEnumerable<KeyValuePair<string, string>> details);

        void RegisterLeftAction(IViewAction viewAction);
        void RegisterRightAction(IViewAction viewAction);
    }
}
