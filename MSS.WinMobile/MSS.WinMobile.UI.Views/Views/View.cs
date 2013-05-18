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

        public delegate void OnLoad(object sender, EventArgs e);
        public event OnLoad Load;

        //private bool _firstTime;
        //protected override void OnParentChanged(EventArgs e) {
        //    base.OnParentChanged(e);

        //    if (!_firstTime) {
        //        if (Load != null)
        //            Load.Invoke(this, e);
        //        _firstTime = true;
        //    }
        //}

        public void ShowInformation(string message) {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.None,
                            MessageBoxDefaultButton.Button1);
        }

        public void ShowError(string message) {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
        }

        public bool ShowConfirmation(string message) {
            return DialogResult.Yes ==
                   MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2);
        }
    }
}
