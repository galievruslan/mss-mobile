using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters;

namespace MSS.WinMobile.UI.Views
{
    public partial class MenuView : Form, IMenuView
    {
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

        public void DisplayErrors(string error)
        {
            
        }

        private SynchronizationView _synchronizationView;

        private void _synchronizationLabel_Click(object sender, System.EventArgs e)
        {
            if (_synchronizationView == null)
                _synchronizationView = new SynchronizationView();

            _synchronizationView.Show();
        }

        private CustomersView _customersView;

        private void _customersLabel_Click(object sender, System.EventArgs e)
        {
            if (_customersView == null)
                _customersView = new CustomersView();

            _customersView.Show();
        }

        private RouteView _routeView;

        private void _routeLabel_Click(object sender, System.EventArgs e)
        {
            if (_routeView == null)
                _routeView = new RouteView();

            _routeView.Show();
        }
    }
}