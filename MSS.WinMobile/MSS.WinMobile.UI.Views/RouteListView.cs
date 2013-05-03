using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class RouteListView : Form, IRouteListView {

        private RouteListPresenter _presenter;
        private readonly PresentersFactory _presentersFactory;

        public RouteListView()
        {
            InitializeComponent();
        }

        public RouteListView(PresentersFactory presentersFactory)
        {
            _presentersFactory = presentersFactory;
            InitializeComponent();
        }

        private void ViewLoad(object sender, EventArgs e)
        {
            if (_presenter == null) {
                _presenter = _presentersFactory.CreateRouteListPresenter(this);
                routeListBox.SetListSize(_presenter.InitializeList());
            }
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
                return DialogViewResult.Ok;

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

        private void CreateRouteClick(object sender, EventArgs e)
        {

        }

        private void OpenRouteClick(object sender, EventArgs e)
        {

        }
    }
}