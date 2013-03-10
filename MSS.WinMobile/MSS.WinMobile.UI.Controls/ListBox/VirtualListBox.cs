using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls.ListBox
{
    public partial class VirtualListBox : UserControl, IListBox
    {
        // Designer only
        public VirtualListBox()
        {
            InitializeComponent();
        }

        public event OnItemDataNeeded ItemDataNeeded;
        public event OnItemSelected ItemSelected;

        private int _itemCount;
        public int ItemCount {
            get { return _itemCount; }
            set
            {
                if (_itemCount == value) return;
                _itemCount = value;

                FillItemPanel();
                if (_itemCount > _listBoxItems.Count)
                    _vScrollBar.Show();
                else
                    _vScrollBar.Hide();

                _vScrollBar.Maximum = _vScrollBar.Minimum + _itemCount - 1;
            }
        }

        private int _selecteIndex = -1;
        public int SelectedIndex {
            get { return _selecteIndex; }
            set { _selecteIndex = value; }
        }

        private void FillItemPanel()
        {
            int itemsHeight = _listBoxItems.Sum(item =>
            {
                var control = item as Control;
                return control != null ? control.Height : 0;
            });

            float itemAvgHeight = 0;
            if (itemsHeight != 0)
                itemAvgHeight = ((float)itemsHeight) / _listBoxItems.Count;

            while (_dataPanel.Height - itemsHeight > 0)
            {
                IListBoxItem listBoxItem = new VirtualListBoxItem();
                AddListBoxItem(listBoxItem);

                var control = listBoxItem as Control;
                itemsHeight += control.Height;
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

        readonly List<IListBoxItem> _listBoxItems = new List<IListBoxItem>();
        private void AddListBoxItem(IListBoxItem listBoxItem)
        {
            if (listBoxItem is Control)
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
        }

        void ListBoxItemSelected(object sender)
        {
            foreach (var item in _listBoxItems)
            {
                if (item.IsSelected)
                {
                    item.IsSelected = false;
                    var control = item as Control;
                    if (control != null)
                        control.Refresh();
                }
            }

            var listBoxItem = sender as IListBoxItem;
            if (listBoxItem != null)
            {
                SelectedIndex = listBoxItem.Index;
                listBoxItem.IsSelected = true;
                if (ItemSelected != null)
                    ItemSelected.Invoke(this, listBoxItem);

                var control = listBoxItem as Control;
                if (control != null)
                    control.Refresh();
            }
        }

        private void RemoveListBoxItem()
        {
            var listBoxItem = _listBoxItems[_listBoxItems.Count - 1];
            if (_dataPanel.Controls.Contains(listBoxItem as Control))
                _dataPanel.Controls.Remove(listBoxItem as Control);

            listBoxItem.DataNeeded -= ListBoxItemDataNeeded;
            listBoxItem.Selected -= ListBoxItemSelected;
            _listBoxItems.Remove(listBoxItem);
        }

        void ListBoxItemDataNeeded(object sender)
        {
            if (ItemDataNeeded != null)
                ItemDataNeeded.Invoke(this, sender as IListBoxItem);
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
    }
}
