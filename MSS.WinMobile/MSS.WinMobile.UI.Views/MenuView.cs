using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters;

namespace MSS.WinMobile.UI.Views
{
    public partial class MenuView : UserControl, IMenuView
    {
        private readonly MenuPresenter _menuPresenter;

        // Designer only usage
        internal MenuView()
        {
            InitializeComponent();
        }

        public MenuView(ILayout layout)
        {
            InitializeComponent();
            _menuPresenter = new MenuPresenter(layout, this);
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