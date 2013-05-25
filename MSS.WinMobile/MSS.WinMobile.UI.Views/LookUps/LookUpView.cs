using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.LookUps
{
    public partial class LookUpView : Form, IView
    {
        public LookUpView()
        {
            InitializeComponent();
        }

        public void ShowInformation(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.None,
                            MessageBoxDefaultButton.Button1);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
        }

        public bool ShowConfirmation(string message)
        {
            return DialogResult.Yes ==
                   MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2);
        }

        public void ShowDetails(string details) {
            _details.Text = details;
            _details.Visible = true;
        }

        private void OkMenuItemClick(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();

        }

        private void CancelMenuItemClick(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}