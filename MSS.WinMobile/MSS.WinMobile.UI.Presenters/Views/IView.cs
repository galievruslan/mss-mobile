using System;
using System.Collections.Generic;

namespace MSS.WinMobile.UI.Presenters.Views
{
    public interface IView : IDisposable {
        void ShowInformation(string message);
        void ShowError(IEnumerable<string> messages);
        bool ShowConfirmation(string messages);

        /// <summary>
        /// Shows details as FieldName: FieldValue
        /// </summary>
        /// <param name="details">Set of pair FieldName, FieldValue</param>
        void ShowDetails(IEnumerable<KeyValuePair<string, string>> details);
    }
}
