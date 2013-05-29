using System.Windows.Forms;
using MSS.WinMobile.Resources;
using MSS.WinMobile.UI.Views.Views;
using View = MSS.WinMobile.UI.Views.Views.View;

namespace MSS.WinMobile.UI.Views {
    public partial class Main : Form, IViewContainer {
        internal Main() {
            InitializeComponent();
        }

        private readonly ILocalizator _localizator;
        public Main(ILocalizator localizator) : this() {
            _localizator = localizator;
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
            MessageBox.Show(_localizator.Localization.GetLocalizedValue(message),
                            _localizator.Localization.GetLocalizedValue("Information"),
                            MessageBoxButtons.OK, MessageBoxIcon.None,
                            MessageBoxDefaultButton.Button1);
        }

        public void ShowError(string message) {
            MessageBox.Show(_localizator.Localization.GetLocalizedValue(message),
                            _localizator.Localization.GetLocalizedValue("error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
        }

        public bool ShowConfirmation(string message) {
            return DialogResult.Yes ==
                   MessageBox.Show(_localizator.Localization.GetLocalizedValue(message),
                                   _localizator.Localization.GetLocalizedValue("confirmation"),
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2);
        }

        public void ShowDetails(string details)
        {
            _details.Text = details;
            _details.Visible = true;
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
                Text = _localizator.Localization.GetLocalizedValue(viewAction.Caption)
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
                Text = _localizator.Localization.GetLocalizedValue(viewAction.Caption)
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