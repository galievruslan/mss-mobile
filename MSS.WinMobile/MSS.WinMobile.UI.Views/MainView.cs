using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class MainView : Form, IMainView
    {
        private MainPresenter _presenter;

        public MainView()
        {
            InitializeComponent();
        }

        private void ViewLoad(object sender, System.EventArgs e)
        {
            _presenter = new MainPresenter(this);
            _presenter.InitializeView();
        }

        #region IView

        public void ShowView()
        {
            Show();
        }

        public DialogViewResult ShowDialogView()
        {
            DialogResult dialogResult = ShowDialog();
            if (dialogResult == DialogResult.OK)
                return DialogViewResult.OK;

            return DialogViewResult.Cancel;
        }

        public void CloseView()
        {
            Close();
        }

        public void DisplayErrors(string error)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}