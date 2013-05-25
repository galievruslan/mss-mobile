using System;
using System.Drawing;
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
        protected VirtualListBox() {
            SelectedIndex = -1;
        }

        public event OnItemDataNeeded ItemDataNeeded;
        public event OnItemSelected ItemSelected;

        private int _itemCount;
        public void SetListSize(int size) {
            SelectedIndex = -1;
            if (_itemCount != size) {
                _itemCount = size;

                FillItemPanel();

                if (_itemCount > _items.Count) {
                    _vScrollBar.LargeChange = _items.Count + 1;
                    _vScrollBar.SmallChange = 1;
                    _vScrollBar.Maximum = _vScrollBar.Minimum + _itemCount;

                    _vScrollBar.Show();
                }
                else
                    _vScrollBar.Hide();
            }

            _vScrollBar.Value = 0;
            ReindexItems();
        }

        private int SelectedIndex { get; set; }

        private void FillItemPanel()
        {
            Refresh();
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

        protected virtual void AddListBoxItem(VirtualListBoxItem item)
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

        protected virtual string EmptyListMessage {
            get { return "Where are no items."; }
        }

        private void DataPanelPaint(object sender, PaintEventArgs e) {
            if (_itemCount == 0) {
                var format = new StringFormat {
                    Alignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.NoClip
                };

                e.Graphics.DrawString(EmptyListMessage, Font, new SolidBrush(ForeColor),
                                      ClientRectangle, format);
            }
        }
    }
}
