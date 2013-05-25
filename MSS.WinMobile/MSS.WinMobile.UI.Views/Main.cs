using System.Windows.Forms;
using View = MSS.WinMobile.UI.Views.Views.View;

namespace MSS.WinMobile.UI.Views {
    public partial class Main : Form, IViewContainer {
        public Main() {
            InitializeComponent();
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
            _leftButton = new MenuItem();
            _leftButton.Text = viewAction.Caption;
            _leftButton.Click += viewAction.Do;
            _mainMenu.MenuItems.Add(_leftButton);
        }

        public void RegisterRightAction(IViewAction viewAction) {
            if (_rightButton != null) {
                _mainMenu.MenuItems.Remove(_rightButton);
                _rightButton.Dispose();
            }
            _rightButton = new MenuItem();
            _rightButton.Text = viewAction.Caption;
            _rightButton.Click += viewAction.Do;
            _mainMenu.MenuItems.Add(_rightButton);
        }
    }
}