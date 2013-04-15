using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Views
{
    public partial class MenuView : Form, IMenuView
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MenuView));

        private MenuPresenter _presenter;
        
        public MenuView()
        {
            InitializeComponent();
        }

        private void MenuView_Load(object sender, System.EventArgs e)
        {
            if (_presenter == null)
            {
                _presenter = new MenuPresenter(this);
                _presenter.InitializeView();
            }
        }

        private void _synchronizationLabel_Click(object sender, System.EventArgs e)
        {
            _presenter.ShowSyncView();
        }

        private void RouteClick(object sender, System.EventArgs e)
        {
            _presenter.ShowRouteView();
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
            Dispose();
        }

        public void DisplayErrors(string error)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}