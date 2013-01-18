using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters;

namespace MSS.WinMobile.UI.Views
{
    public partial class MenuView : Form, IMenuView
    {
        private readonly MenuPresenter _menuPresenter;

        public MenuView()
        {
            InitializeComponent();
            _menuPresenter = new MenuPresenter();
        }

        public void NavigateTo<T>() where T : IView
        {
            this.Navigate<T>();
        }

        public void ShowErrorDialog(string message)
        {
            this.ShowErrDialog(message);
        }

        public void ShowInformationDialog(string message)
        {
            this.ShowInfoDialog(message);
        }

        public bool ShowConfirmationDialog(string question)
        {
            return this.ShowConfirmDialog(question);
        }

        private void _goRouteButton_Click(object sender, EventArgs e)
        {
            _menuPresenter.Route();
        }

        private void _goCustomersButton_Click(object sender, EventArgs e)
        {
            _menuPresenter.Customers();
        }

        private void _goSynchronizationButton_Click(object sender, EventArgs e)
        {
            _menuPresenter.Synchronization();
        }

        private void _goBaliBaliButton_Click(object sender, EventArgs e)
        {
            _menuPresenter.BaliBali();
        }
    }
}