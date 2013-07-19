using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.Localization;
using MSS.WinMobile.UI.Controls;
using MSS.WinMobile.UI.Views.Views;
using View = MSS.WinMobile.UI.Views.Views.View;

namespace MSS.WinMobile.UI.Views {
    public partial class Main : Form, IViewContainer {
        internal Main() {
            InitializeComponent();
        }

        private readonly ILocalizationManager _localizationManager;
        public Main(ILocalizationManager localizationManager) : this() {
            _localizationManager = localizationManager;
        }

        public void SetView(View view) {
            UnregisterActions();
            foreach (Control control in Controls) {
                if (control is View) {
                    Controls.Remove(control);
                    control.Dispose();
                    break;
                }
            }

            view.Dock = DockStyle.Fill;
            view.SetContainer(this);
            Controls.Add(view);
        }

        public void ShowInformation(string message) {
            MessageBox.Show(_localizationManager.Localization.GetLocalizedValue(message),
                            _localizationManager.Localization.GetLocalizedValue("Information"),
                            MessageBoxButtons.OK, MessageBoxIcon.None,
                            MessageBoxDefaultButton.Button1);
        }

        public void ShowError(IEnumerable<string> messages) {
            var stringBuilder = new StringBuilder();
            foreach (var message in messages) {
                stringBuilder.Append(_localizationManager.Localization.GetLocalizedValue(message));
                stringBuilder.Append(Environment.ReturnWithNewLine);
            }
            MessageBox.Show(stringBuilder.ToString(),
                            _localizationManager.Localization.GetLocalizedValue("Error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
        }

        public bool ShowConfirmation(string message) {
            return DialogResult.Yes ==
                   MessageBox.Show(_localizationManager.Localization.GetLocalizedValue(message),
                                   _localizationManager.Localization.GetLocalizedValue("confirmation"),
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2);
        }

        public void ShowDetails(IEnumerable<KeyValuePair<string, string>> details) {
            var stringBuilder = new StringBuilder();
            foreach (var keyValuePair in details) {
                stringBuilder.Append(string.Format("{0}: {1}",
                                                   _localizationManager.Localization.GetLocalizedValue(
                                                       keyValuePair.Key),
                                                   keyValuePair.Value));
                stringBuilder.Append(Environment.NewLine);
            }

            var detailsWindow = new DetailsWindow(stringBuilder.ToString());
            detailsWindow.Text = _localizationManager.Localization.GetLocalizedValue(detailsWindow.Text);
            detailsWindow.ShowDialog();
        }

        public void UnregisterActions() {
            if (_leftButton != null)
            {
                _mainMenu.MenuItems.Remove(_leftButton);
                _leftButton.Dispose();
            }
            if (_rightButton != null)
            {
                _mainMenu.MenuItems.Remove(_rightButton);
                _rightButton.Dispose();
            }
        }

        public void RegisterLeftAction(IViewAction viewAction) {
            if (_leftButton != null) {
                _mainMenu.MenuItems.Remove(_leftButton);
                _leftButton.Dispose();
            }
            _leftButton = new MenuItem {
                Text = _localizationManager.Localization.GetLocalizedValue(viewAction.Caption)
            };
            if (!(viewAction is StubAction)) {
                _leftButton.Click += viewAction.Do;
            }
            else {
                _leftButton.Enabled = false;
            }

            _mainMenu.MenuItems.Add(_leftButton);
        }

        public void RegisterRightAction(IViewAction viewAction) {
            if (_rightButton != null) {
                _mainMenu.MenuItems.Remove(_rightButton);
                _rightButton.Dispose();
            }
            _rightButton = new MenuItem {
                Text = _localizationManager.Localization.GetLocalizedValue(viewAction.Caption)
            };
            if (!(viewAction is StubAction)) {
                _rightButton.Click += viewAction.Do;
            }
            else {
                _rightButton.Enabled = false;
            }

            _mainMenu.MenuItems.Add(_rightButton);
        }
    }
}