using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.ListBox
{
    public abstract partial class VirtualListBox<T> : UserControl where T : class 
    {
        public delegate void OnItemDataNeeded(object sender, VirtualListBoxItem<T> item);
        public delegate void OnItemSelected(object sender, VirtualListBoxItem<T> item);

        // Designer only
        protected VirtualListBox()
        {
            InitializeComponent();
        }

        public event OnItemDataNeeded ItemDataNeeded;
        public event OnItemSelected ItemSelected;

        private int _itemCount;

        public void SetListSize(int size)
        {
            if (_itemCount == size) return;
            _itemCount = size;

            FillItemPanel();
            if (_itemCount > _listBoxItems.Count)
                _vScrollBar.Show();
            else
                _vScrollBar.Hide();

            _vScrollBar.Maximum = _vScrollBar.Minimum + _itemCount - 1;
        }

        private int _selecteIndex = -1;
        public int SelectedIndex {
            get { return _selecteIndex; }
            set { _selecteIndex = value; }
        }

        private void FillItemPanel()
        {
            int itemsHeight = _listBoxItems.Sum(item => item.Height);

            float itemAvgHeight = 0;
            if (itemsHeight != 0)
                itemAvgHeight = ((float)itemsHeight) / _listBoxItems.Count;

            while (_dataPanel.Height - itemsHeight > 0)
            {
                VirtualListBoxItem<T> listBoxItem = NewItem();
                AddListBoxItem(listBoxItem);

                itemsHeight += listBoxItem.Height;
                itemAvgHeight = ((float)itemsHeight) / _listBoxItems.Count;
            }

            while (_dataPanel.Height - itemsHeight + itemAvgHeight < 0)
            {
                RemoveListBoxItem();

                itemsHeight = _listBoxItems.Sum(item =>
                {
                    var control = item as Control;
                    return control != null ? control.Height : 0;
                });
            }

            foreach (var listBoxItem in _listBoxItems)
            {
                var control = listBoxItem as Control;
                if (control != null) control.Width = _dataPanel.Width;
            }

            ReindexItems();
        }

        #region Items Handling

        readonly List<VirtualListBoxItem<T>> _listBoxItems = new List<VirtualListBoxItem<T>>();

        private void AddListBoxItem(VirtualListBoxItem<T> listBoxItem)
        {
            var listBoxItemControl = listBoxItem as Control;
            if (_listBoxItems.Count > 0)
            {
                var lastListBoxItem = _listBoxItems[_listBoxItems.Count - 1] as Control;
                if (lastListBoxItem != null)
                    listBoxItemControl.Top = lastListBoxItem.Top + lastListBoxItem.Height;
            }

            listBoxItem.DataNeeded += ListBoxItemDataNeeded;
            listBoxItem.Selected += ListBoxItemSelected;
            var control = listBoxItem as Control;
            control.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            _dataPanel.Controls.Add(control);
            _listBoxItems.Add(listBoxItem);
        }

        private void ListBoxItemSelected(VirtualListBoxItem<T> sender)
        {
            // return if listbox doesn't contains data
            if (sender.Data == null)
                return;

            foreach (var item in _listBoxItems)
            {
                if (item.IsSelected)
                {
                    item.IsSelected = false;
                    item.Refresh();
                }
            }

            SelectedIndex = sender.Index;
            sender.IsSelected = true;

            if (ItemSelected != null)
                ItemSelected.Invoke(this, sender);

            sender.Refresh();
        }

        private void RemoveListBoxItem()
        {
            var listBoxItem = _listBoxItems[_listBoxItems.Count - 1];
            if (_dataPanel.Controls.Contains(listBoxItem))
                _dataPanel.Controls.Remove(listBoxItem);

            listBoxItem.DataNeeded -= ListBoxItemDataNeeded;
            listBoxItem.Selected -= ListBoxItemSelected;
            _listBoxItems.Remove(listBoxItem);
        }

        void ListBoxItemDataNeeded(object sender)
        {
            if (ItemDataNeeded != null)
                ItemDataNeeded.Invoke(this, sender as VirtualListBoxItem<T>);
        }

        private void ReindexItems()
        {
            for (int i = 0; i < _listBoxItems.Count; i++)
            {
                var item = _listBoxItems[i];
                item.Index = _vScrollBar.Value + (-_vScrollBar.Minimum) + i;
                item.IsSelected = item.Index == SelectedIndex;

                var control = item as Control;
                if (control != null)
                    control.Refresh();
            }
        }

        #endregion

        #region Event Handlers

        private void VScrollBarValueChanged(object sender, EventArgs e)
        {
            ReindexItems();
        }

        #endregion

        protected abstract VirtualListBoxItem<T> NewItem();
    }
}
