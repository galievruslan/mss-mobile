using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters.LookUps;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Views.LookUps;

namespace MSS.WinMobile.UI.Views.LookUps
{
    public partial class PriceListLookUpView : Form, IPriceListLookUpView
    {
        private readonly IPresentersFactory _presentersFactory;
        private PriceListLookUpPresenter _presenter;

        public PriceListLookUpView()
        {
            InitializeComponent();
        }

        public PriceListLookUpView(IPresentersFactory presentersFactory)
        {
            InitializeComponent();
            _presentersFactory = presentersFactory;
        }

        private void ViewLoad(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                _priceListListBox.ItemDataNeeded += ItemDataNeeded;
                _priceListListBox.ItemSelected += ItemSelected;
                _presenter = _presentersFactory.CreatePriceListLookUpPresenter(this);
                _priceListListBox.SetListSize(_presenter.InitializeListSize());
            }
        }

        void ItemSelected(object sender, VirtualListBoxItem item)
        {
            _presenter.Select(item.Index);
        }

        void ItemDataNeeded(object sender, VirtualListBoxItem item)
        {
            var priceListListBoxItem = item as PriceListListBoxItem;
            if (priceListListBoxItem != null)
            {
                priceListListBoxItem.ViewModel =_presenter.GetItem(item.Index);
            }
        }

        public PriceListViewModel SelectedPriceList
        {
            get { return _presenter.SelectedModel; }
        }

        private void CancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            _presenter.Cancel();
        }

        private void OkClick(object sender, EventArgs e)
        {
            if (_presenter.LookUp())
                DialogResult = DialogResult.OK;
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
    }
}