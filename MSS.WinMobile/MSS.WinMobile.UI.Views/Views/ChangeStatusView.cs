using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.Views {
    public partial class ChangeStatusView : View, IChangeStatusView {
        public ChangeStatusView() {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;
        private RoutePointViewModel _routePointViewModel;
        public ChangeStatusView(IPresentersFactory presentersFactory, RoutePointViewModel routePointViewModel) {
            InitializeComponent();
            _presentersFactory = presentersFactory;
            _routePointViewModel = routePointViewModel;
        }

        private ChangeStatusPresenter _changeStatusPresenter;
        private void ChangeStatusViewLoad(object sender, EventArgs e) {
            if (_changeStatusPresenter == null) {
                _changeStatusPresenter = _presentersFactory.CreateChangeStatusPresenter(this,
                                                                                        _routePointViewModel);

                _routePointViewModel = _changeStatusPresenter.Initialize();
                IEnumerable<StatusViewModel> statusViewModels = _changeStatusPresenter.GetStatuses();
                foreach (var statusViewModel in statusViewModels) {
                    var radioButton = new RadioButton {
                        Text = statusViewModel.Name,
                        Checked = statusViewModel.Id == _routePointViewModel.StatusId,
                        Dock = DockStyle.Top,
                        Tag = statusViewModel
                    };
                    radioButton.CheckedChanged += RadioButtonCheckedChanged;
                    _statusesPanel.Controls.Add(radioButton);
                }
            }
        }

        void RadioButtonCheckedChanged(object sender, EventArgs e) {
            var radioButton = sender as RadioButton;
            if (radioButton != null)
                _changeStatusPresenter.SelectStatus(radioButton.Tag as StatusViewModel);
        }

        private void CancelButtonClick(object sender, EventArgs e) {
            _changeStatusPresenter.Cancel();
        }

        private void OkButtonClick(object sender, EventArgs e) {
            _changeStatusPresenter.Save();
        }
    }
}
