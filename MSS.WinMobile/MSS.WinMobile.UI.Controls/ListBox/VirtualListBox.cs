﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.ListBox
{
    public partial class VirtualListBox : UserControl
    {
        public delegate void OnItemDataNeeded(object sender, VirtualListBoxItem item);
        public delegate void OnItemSelected(object sender, VirtualListBoxItem item);

        // Designer only
        protected VirtualListBox()
        {
        }

        public event OnItemDataNeeded ItemDataNeeded;
        public event OnItemSelected ItemSelected;

        private int _itemCount = -1;

        public void SetListSize(int size)
        {
            if (_itemCount != size)
            {
                _itemCount = size;

                FillItemPanel();
                if (_itemCount > _items.Count)
                    _vScrollBar.Show();
                else
                    _vScrollBar.Hide();

                _vScrollBar.Maximum = _vScrollBar.Minimum + _itemCount;
            }
            ReindexItems();
        }

        private int _selecteIndex = -1;

        private int SelectedIndex {
            get { return _selecteIndex; }
            set { _selecteIndex = value; }
        }

        private void FillItemPanel()
        {
            int itemsHeight = _items.Sum(item => item.Height);

            float itemAvgHeight = 0;
            if (itemsHeight != 0)
                itemAvgHeight = ((float)itemsHeight) / _items.Count;

            while (_dataPanel.Height - itemsHeight - itemAvgHeight > 0 &&
                _items.Count < _itemCount)
            {
                VirtualListBoxItem listBoxItem = NewItem();
                AddListBoxItem(listBoxItem);

                itemsHeight += listBoxItem.Height;
                itemAvgHeight = ((float)itemsHeight) / _items.Count;
            }

            while (_dataPanel.Height - itemsHeight < 0 ||
                _items.Count > _itemCount)
            {
                RemoveListBoxItem();
                itemsHeight = _items.Sum(item => item.Height);
            }

            foreach (var listBoxItem in _items)
            {
                listBoxItem.Width = _dataPanel.Width;
            }
        }

        #region Items Handling

        private readonly List<VirtualListBoxItem> _items = new List<VirtualListBoxItem>();

        private void AddListBoxItem(VirtualListBoxItem item)
        {
            if (_items.Any()) {
                var lastListBoxItem = _items.Last();
                item.Top = lastListBoxItem.Top + lastListBoxItem.Height;
            }
            else {
                item.Top = 0;
            }

            item.Left = 0;
            item.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            item.DataNeeded += OnItemDataNeededHandler;
            item.Selected += OnItemSelectedHandler;

            _dataPanel.Controls.Add(item);
            _items.Add(item);
        }

        void OnItemDataNeededHandler(VirtualListBoxItem sender)
        {
            if (ItemDataNeeded != null && sender.Index < _itemCount)
                ItemDataNeeded.Invoke(this, sender);
        }

        void OnItemSelectedHandler(VirtualListBoxItem sender)
        {
            // return if listbox doesn't contains data
            if (sender.Index >= _itemCount)
                return;

            foreach (var item in _items)
            {
                if (item.IsSelected)
                {
                    item.IsSelected = false;
                }
            }

            SelectedIndex = sender.Index;
            sender.IsSelected = true;

            if (ItemSelected != null)
                ItemSelected.Invoke(this, sender);
        }

        private void RemoveListBoxItem()
        {
            var listBoxItem = _items[_items.Count - 1];
            if (_dataPanel.Controls.Contains(listBoxItem))
                _dataPanel.Controls.Remove(listBoxItem);

            listBoxItem.DataNeeded -= OnItemDataNeededHandler;
            listBoxItem.Selected -= OnItemSelectedHandler;
            _items.Remove(listBoxItem);
        }

        private void ReindexItems()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                var item = _items[i];
                item.Index = _vScrollBar.Value + (-_vScrollBar.Minimum) + i;
                item.IsSelected = item.Index == SelectedIndex;
            }
        }

        #endregion

        #region Event Handlers

        private void VScrollBarValueChanged(object sender, EventArgs e)
        {
            ReindexItems();
        }

        #endregion

        protected virtual VirtualListBoxItem NewItem() {
            return null;
        }

        private void VirtualListBoxResize(object sender, EventArgs e)
        {
            foreach (var virtualListBoxItem in _items) {
                virtualListBoxItem.Width = _dataPanel.Width;
            }
        }
    }
}
