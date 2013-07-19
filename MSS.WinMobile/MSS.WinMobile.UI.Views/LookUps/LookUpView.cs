using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.Localization;
using MSS.WinMobile.UI.Controls;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.LookUps
{
    public partial class LookUpView : Form, IView
    {
        internal LookUpView()
        {
            InitializeComponent();
        }

        protected readonly ILocalizationManager LocalizationManager;
        public LookUpView(ILocalizationManager localizationManager) : this() {
            LocalizationManager = localizationManager;

            _okMenuItem.Text = LocalizationManager.Localization.GetLocalizedValue(_okMenuItem.Text);
            _cancelMenuItem.Text = LocalizationManager.Localization.GetLocalizedValue(_cancelMenuItem.Text);
        }

        public void ShowInformation(string message) {
            MessageBox.Show(LocalizationManager.Localization.GetLocalizedValue(message),
                            LocalizationManager.Localization.GetLocalizedValue("Information"),
                            MessageBoxButtons.OK, MessageBoxIcon.None,
                            MessageBoxDefaultButton.Button1);
        }

        public void ShowError(IEnumerable<string> messages) {
            var stringBuilder = new StringBuilder();
            foreach (var message in messages) {
                stringBuilder.Append(LocalizationManager.Localization.GetLocalizedValue(message));
                stringBuilder.Append(Environment.ReturnWithNewLine);
            }
            MessageBox.Show(stringBuilder.ToString(),
                            LocalizationManager.Localization.GetLocalizedValue("Error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
        }

        public bool ShowConfirmation(string messages) {
            return DialogResult.Yes ==
                   MessageBox.Show(LocalizationManager.Localization.GetLocalizedValue(messages),
                                   LocalizationManager.Localization.GetLocalizedValue("Confirmation"),
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2);
        }

        public void ShowDetails(IEnumerable<KeyValuePair<string, string>> details) {
            var stringBuilder = new StringBuilder();
            foreach (var keyValuePair in details) {
                stringBuilder.Append(string.Format("{0}: {1}",
                                                   LocalizationManager.Localization.GetLocalizedValue(
                                                       keyValuePair.Key),
                                                   keyValuePair.Value));
                stringBuilder.Append(Environment.NewLine);
            }

            var detailsWindow = new DetailsWindow(stringBuilder.ToString());
            detailsWindow.Text = LocalizationManager.Localization.GetLocalizedValue(detailsWindow.Text);
            detailsWindow.ShowDialog();
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