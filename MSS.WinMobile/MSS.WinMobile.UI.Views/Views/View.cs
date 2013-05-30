using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.Views {
    public partial class View : UserControl, IView {
        public View() {
            InitializeComponent();

            if (DesignMode.IsTrue)
                return;

            ParentChanged += (sender, e) => Load(sender, e);
        }

        protected IViewContainer ViewContainer;

        public void SetContainer(IViewContainer viewContainer) {
            ViewContainer = viewContainer;
        }

        public delegate void OnLoad(object sender, EventArgs e);

        public event OnLoad Load;

        public void ShowInformation(string message) {
            ViewContainer.ShowInformation(message);
        }

        public void ShowError(IEnumerable<string> messages) {
            ViewContainer.ShowError(messages);
        }

        public bool ShowConfirmation(string messages) {
            return ViewContainer.ShowConfirmation(messages);
        }

        public void ShowDetails(IEnumerable<KeyValuePair<string, string>> details) {
            ViewContainer.ShowDetails(details);
        }
    }

    public class StubAction : IViewAction {
        public string Caption {
            get { return string.Empty; }
        }
        public void Do(object sender, EventArgs e) {}
    }
}
