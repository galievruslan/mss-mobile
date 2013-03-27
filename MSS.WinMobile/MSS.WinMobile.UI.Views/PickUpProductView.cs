using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class PickUpProductView : Form, IPickUpProductView
    {
        private PickUpProductPresenter _presenter;
        private readonly int _priceListId;

        public PickUpProductView()
        {
            InitializeComponent();
        }

        public PickUpProductView(int priceListId)
            :this()
        {
            _priceListId = priceListId;
        }

        private void ViewLoad(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                productsPriceListBox.ItemDataNeeded += ItemDataNeeded;
                productsPriceListBox.ItemSelected += ProductsPriceListBoxItemSelected;
                _presenter = new PickUpProductPresenter(this, _priceListId);
                _presenter.InitializeView();
            }
        }

        void ProductsPriceListBoxItemSelected(object sender, VirtualListBoxItem item)
        {

        }

        void ItemDataNeeded(object sender, VirtualListBoxItem item)
        {
            var productPriceListBoxItem = item as ProductPriceListBoxItem;
            if (productPriceListBoxItem != null)
            {
                productPriceListBoxItem.SetData(_presenter.GetItemData(item.Index));
            }
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public void DisplayErrors(string error)
        {
            throw new NotImplementedException();
        }

        public void SetItemCount(int count)
        {
            productsPriceListBox.SetListSize(count);
        }

        public int GetSelectedId()
        {
            throw new NotImplementedException();
        }
    }
}