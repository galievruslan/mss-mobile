using System.Windows.Forms;
using MSS.WinMobile.Resources;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.LookUps
{
    public partial class LookUpView : Form, IView
    {
        internal LookUpView()
        {
            InitializeComponent();
        }

        protected readonly ILocalizator Localizator;
        public LookUpView(ILocalizator localizator) : this() {
            Localizator = localizator;

            Text = Localizator.Localization.GetLocalizedValue(Text);
            _okMenuItem.Text = Localizator.Localization.GetLocalizedValue(_okMenuItem.Text);
            _cancelMenuItem.Text = Localizator.Localization.GetLocalizedValue(_cancelMenuItem.Text);
        }

        public void ShowInformation(string message) {
            MessageBox.Show(Localizator.Localization.GetLocalizedValue(message),
                            Localizator.Localization.GetLocalizedValue("Information"),
                            MessageBoxButtons.OK, MessageBoxIcon.None,
                            MessageBoxDefaultButton.Button1);
        }

        public void ShowError(string message) {
            MessageBox.Show(Localizator.Localization.GetLocalizedValue(message),
                            Localizator.Localization.GetLocalizedValue("Error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
        }

        public bool ShowConfirmation(string message) {
            return DialogResult.Yes ==
                   MessageBox.Show(Localizator.Localization.GetLocalizedValue(message),
                                   Localizator.Localization.GetLocalizedValue("Confirmation"),
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question,
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