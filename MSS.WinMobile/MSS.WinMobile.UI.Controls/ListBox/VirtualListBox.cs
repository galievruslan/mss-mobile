using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.ListBox
{
    public abstract partial class VirtualListBox : UserControl
    {
        public delegate void OnItemDataNeeded(object sender, VirtualListBoxItem item);
        public delegate void OnItemSelected(object sender, VirtualListBoxItem item);

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
            if (_itemCount > Items.Count)
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
            int itemsHeight = Items.Sum(item => item.Height);

            float itemAvgHeight = 0;
            if (itemsHeight != 0)
                itemAvgHeight = ((float)itemsHeight) / Items.Count;

            while (_dataPanel.Height - itemsHeight > 0)
            {
                VirtualListBoxItem listBoxItem = NewItem();
                AddListBoxItem(listBoxItem);

                itemsHeight += listBoxItem.Height;
                itemAvgHeight = ((float)itemsHeight) / Items.Count;
            }

            while (_dataPanel.Height - itemsHeight + itemAvgHeight < 0)
            {
                RemoveListBoxItem();

                itemsHeight = Items.Sum(item =>
                {
                    var control = item as Control;
                    return control != null ? control.Height : 0;
                });
            }

            foreach (var listBoxItem in Items)
            {
                var control = listBoxItem as Control;
                if (control != null) control.Width = _dataPanel.Width;
            }

            ReindexItems();
        }

        #region Items Handling

        public readonly List<VirtualListBoxItem> Items = new List<VirtualListBoxItem>();

        private void AddListBoxItem(VirtualListBoxItem item)
        {
            var listBoxItemControl = item as Control;
            if (Items.Count > 0)
            {
                var lastListBoxItem = Items[Items.Count - 1] as Control;
                if (lastListBoxItem != null)
                    listBoxItemControl.Top = lastListBoxItem.Top + lastListBoxItem.Height;
            }

            item.DataNeeded += ListBoxItemDataNeeded;
            item.Selected += ListBoxItemSelected;
            var control = item as Control;
            control.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
            _dataPanel.Controls.Add(control);
            Items.Add(item);
        }

        private void ListBoxItemSelected(VirtualListBoxItem sender)
        {
            // return if listbox doesn't contains data
            if (sender.Index >= _itemCount)
                return;

            foreach (var item in Items)
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
            var listBoxItem = Items[Items.Count - 1];
            if (_dataPanel.Controls.Contains(listBoxItem))
                _dataPanel.Controls.Remove(listBoxItem);

            listBoxItem.DataNeeded -= ListBoxItemDataNeeded;
            listBoxItem.Selected -= ListBoxItemSelected;
            Items.Remove(listBoxItem);
        }

        void ListBoxItemDataNeeded(VirtualListBoxItem sender)
        {
            if (ItemDataNeeded != null && sender.Index < _itemCount)
                ItemDataNeeded.Invoke(this, sender);
        }

        private void ReindexItems()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                var item = Items[i];
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

        protected abstract VirtualListBoxItem NewItem();
    }
}
