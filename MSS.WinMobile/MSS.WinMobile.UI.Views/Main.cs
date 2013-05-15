using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views {
    public partial class Main : Form, IViewContainer {
        public Main() {
            InitializeComponent();
        }

        public void SetView(IView view) {
            foreach (Control control in Controls) {
                if (control is IView) {
                    Controls.Remove(control);
                    control.Dispose();
                    break;
                }
            }

            var newControl = view as Control;
            if (newControl != null) {
                newControl.Dock = DockStyle.Fill;
                Controls.Add(newControl);
            }
        }
    }
}