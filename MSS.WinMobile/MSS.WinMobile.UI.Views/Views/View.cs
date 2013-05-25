using System;
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

        public void ShowError(string message) {
            ViewContainer.ShowError(message);
        }

        public bool ShowConfirmation(string message) {
            return ViewContainer.ShowConfirmation(message);
        }

        public void ShowDetails(string details) {
            ViewContainer.ShowDetails(details);
        }
    }
}
