using System.Collections.Generic;
using System.Text;
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

            _okMenuItem.Text = Localizator.Localization.GetLocalizedValue(_okMenuItem.Text);
            _cancelMenuItem.Text = Localizator.Localization.GetLocalizedValue(_cancelMenuItem.Text);
        }

        public void ShowInformation(string message) {
            MessageBox.Show(Localizator.Localization.GetLocalizedValue(message),
                            Localizator.Localization.GetLocalizedValue("Information"),
                            MessageBoxButtons.OK, MessageBoxIcon.None,
                            MessageBoxDefaultButton.Button1);
        }

        public void ShowError(IEnumerable<string> messages) {
            var stringBuilder = new StringBuilder();
            foreach (var message in messages) {
                stringBuilder.Append(Localizator.Localization.GetLocalizedValue(message));
                stringBuilder.Append("\n\r");
            }
            MessageBox.Show(stringBuilder.ToString(),
                            Localizator.Localization.GetLocalizedValue("Error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
        }

        public bool ShowConfirmation(string messages) {
            return DialogResult.Yes ==
                   MessageBox.Show(Localizator.Localization.GetLocalizedValue(messages),
                                   Localizator.Localization.GetLocalizedValue("Confirmation"),
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2);
        }

        public void ShowDetails(IEnumerable<KeyValuePair<string, string>> details) {
            var stringBuilder = new StringBuilder();
            foreach (var keyValuePair in details) {
                stringBuilder.Append(string.Format("<b>{0}</b>: {1}",
                                                   Localizator.Localization.GetLocalizedValue(
                                                       keyValuePair.Key),
                                                   keyValuePair.Value));
                stringBuilder.Append("</br>");
            }
            _details.Text = stringBuilder.ToString();
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