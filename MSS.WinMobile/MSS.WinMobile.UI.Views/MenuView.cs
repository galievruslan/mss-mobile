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

        private RouteView _routeView;

        private void _routeLabel_Click(object sender, System.EventArgs e)
        {
            Log.Debug("Redirect to RouteView begin.");
            if (_routeView == null)
            {
                Log.Debug("Construct RouteView begin.");
                _routeView = new RouteView();
                Log.Debug("Construct RouteView finish.");
            }

            Log.Debug("Show RouteView begin.");
            _routeView.Show();
            Log.Debug("Show RouteView finish.");
            Log.Debug("Redirect to RouteView finish.");
        }
    }
}