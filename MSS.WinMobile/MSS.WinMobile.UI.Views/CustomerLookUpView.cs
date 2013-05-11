using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class CustomerLookUpView : Form, ICustomerLookUpView
    {
        public CustomerLookUpView()
        {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;
        private CustomerLookUpPresenter _presenter;

        public CustomerLookUpView(IPresentersFactory presentersFactory) {
            InitializeComponent();
            _presentersFactory = presentersFactory;
        }

        private void CustomerLookUpView_Load(object sender, EventArgs e)
        {
            if (_presenter == null) {
                _presenter = _presentersFactory.CreateCustomerLookUpPresenter(this);
                customerListBox.ItemDataNeeded += customerListBox_ItemDataNeeded;
                customerListBox.ItemSelected += customerListBox_ItemSelected;
                customerListBox.SetListSize(_presenter.InitializeListSize());
            }
        }

        void customerListBox_ItemSelected(object sender, VirtualListBoxItem item) {
            _presenter.Select(item.Index);
        }

        void customerListBox_ItemDataNeeded(object sender, VirtualListBoxItem item)
        {
            var customerListBoxItem = item as CustomerListBoxItem;
            if (customerListBoxItem != null)
            {
                customerListBoxItem.ViewModel = _presenter.GetItem(item.Index);
            }
        }

        public CustomerViewModel SelectedCustomer {
            get { return _presenter.SelectedModel; }
        }

        #region IView

        public void ShowView() {
            Show();
        }

        public DialogViewResult ShowDialogView() {
            DialogResult dialogResult = ShowDialog();
            if (dialogResult == DialogResult.OK)
                return DialogViewResult.Ok;

            return DialogViewResult.Cancel;
        }

        public void CloseView() {
            Close();
            Dispose();
        }

        public void DisplayErrors(string error) {
            throw new NotImplementedException();
        }

        #endregion

        private void OkButtonClick(object sender, EventArgs e) {
            if (_presenter.LookUp())
                DialogResult = DialogResult.OK;
        }

        private void CancelButtonClick(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            _presenter.Cancel();
        }
    }
}