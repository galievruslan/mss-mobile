using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class PriceListLookUpView : Form, IPriceListLookUpView
    {
        private PriceListLookUpPresenter _presenter;

        public PriceListLookUpView()
        {
            InitializeComponent();
        }

        private void ViewLoad(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                //priceListListBox.ItemDataNeeded += ItemDataNeeded;
                //priceListListBox.ItemSelected += ItemSelected;
                //_presenter = new PriceListLookUpPresenter(this);
                //_presenter.InitializeView();
            }
        }

        void ItemDataNeeded(object sender, VirtualListBoxItem item)
        {
            //var priceListListBoxItem = item as PriceListListBoxItem;
            //if (priceListListBoxItem != null)
            //{
            //    priceListListBoxItem.SetData(_presenter.GetItemData(item.Index));
            //}
        }

        private void CancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public void SetItemCount(int count)
        {
            //priceListListBox.SetListSize(count);
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