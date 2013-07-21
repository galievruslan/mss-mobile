using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MSS.WinMobile.Localization;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.ListBox
{
    public partial class NewVirtualListBox : UserControl
    {
        public delegate void OnItemDataNeeded(object sender, NewVirtualListBoxItem item);
        public delegate void OnItemSelected(object sender, NewVirtualListBoxItem item);

        // Designer only
        protected NewVirtualListBox() {
            SelectedIndex = -1;
        }

        public ILocalizationManager LocalizationManager { private get; set; }

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
                NewVirtualListBoxItem listBoxItem = NewItem();
                if (LocalizationManager != null)
                    listBoxItem.LocalizationManager = LocalizationManager;

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

        private readonly List<NewVirtualListBoxItem> _items = new List<NewVirtualListBoxItem>();

        protected virtual void AddListBoxItem(NewVirtualListBoxItem item)
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
            item.MouseDown += item_MouseDown;
            item.MouseUp += item_MouseUp;
            item.MouseMove += item_MouseMove;
            item.Click += ItemClick;

            _dataPanel.Controls.Add(item);
            _items.Add(item);
        }

        private bool _sliding;
        void item_MouseMove(object sender, MouseEventArgs e) {
            if (_sliding) {
                var item = sender as NewVirtualListBoxItem;
                if (item != null) {
                    
                }
            }
        }

        void item_MouseUp(object sender, MouseEventArgs e) {
            _sliding = false;
        }

        void item_MouseDown(object sender, MouseEventArgs e) {
            _sliding = true;
        }

        void ItemClick(object sender, EventArgs e) {
            foreach (NewVirtualListBoxItem each in _items) {
                if (each.Index == SelectedIndex) {
                    each.UnSelect();
                    break;
                }
            }

            var item = sender as NewVirtualListBoxItem;
            if (item != null) {
                item.Select();
                SelectedIndex = item.Index;

                if (ItemSelected != null) {
                    ItemSelected.Invoke(this, item);
                }
            }
        }

        void OnItemDataNeededHandler(NewVirtualListBoxItem sender)
        {
            if (ItemDataNeeded != null && sender.Index < _itemCount)
                ItemDataNeeded.Invoke(this, sender);
        }

        private void RemoveListBoxItem()
        {
            var listBoxItem = _items[_items.Count - 1];
            if (_dataPanel.Controls.Contains(listBoxItem))
                _dataPanel.Controls.Remove(listBoxItem);

            listBoxItem.DataNeeded -= OnItemDataNeededHandler;
            listBoxItem.Click -= ItemClick;
            _items.Remove(listBoxItem);
        }

        private void ReindexItems()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                var item = _items[i];
                item.Index = _vScrollBar.Value + (-_vScrollBar.Minimum) + i;
                if (item.Index == SelectedIndex) {
                    item.Select();
                }
            }
        }

        #endregion

        #region Event Handlers

        private void VScrollBarValueChanged(object sender, EventArgs e)
        {
            ReindexItems();
        }

        #endregion

        protected virtual NewVirtualListBoxItem NewItem() {
            return null;
        }

        protected virtual string EmptyListMessage {
            get { return "Where are no items."; }
        }

        private void DataPanelPaint(object sender, PaintEventArgs e) {
            if (_itemCount == 0) {
                var format = new StringFormat {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.NoClip
                };

                string emptyStringMessage = EmptyListMessage;
                if (LocalizationManager != null)
                    emptyStringMessage =
                        LocalizationManager.Localization.GetLocalizedValue(emptyStringMessage);

                e.Graphics.DrawString(emptyStringMessage, Font, new SolidBrush(ForeColor),
                                      ClientRectangle, format);
            }
        }
    }
}
