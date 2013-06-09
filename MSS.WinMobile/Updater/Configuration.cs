using System.Windows.Forms;

namespace Updater {
    public partial class Configuration : Form {
        public Configuration() {
            InitializeComponent();
            Config = new UpdaterConfig();
        }

        private void CheckUpdatesMenuItemClick(object sender, System.EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelUpdatesMenuItemClick(object sender, System.EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public UpdaterConfig Config { get; private set; }

        private void TargetTextBoxTextChanged(object sender, System.EventArgs e) {
            Config.Target = _targetTextBox.Text;
        }

        private void ServerTextBoxTextChanged(object sender, System.EventArgs e) {
            Config.Address = _serverTextBox.Text;
        }

        private void LoginTextBoxTextChanged(object sender, System.EventArgs e) {
            Config.Login = _loginTextBox.Text;
        }

        private void PasswordTextBoxTextChanged(object sender, System.EventArgs e) {
            Config.Password = _passwordTextBox.Text;
        }
    }
}