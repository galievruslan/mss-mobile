using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls.ListBox
{
    public partial class VirtualListBox<T> : UserControl, IListBox<T> where T : class 
    {
        // Designer only
        public VirtualListBox()
        {
            InitializeComponent();
        }

        public event OnItemDataNeeded<T> ItemDataNeeded;

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

                _vScrollBar.Maximum = _vScrollBar.Minimum + _itemCount;
            }
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

            while (itemAvgHeight < _dataPanel.Height - itemsHeight)
            {
                IListBoxItem<T> listBoxItem = GetNewListItem();
                AddListBoxItem(listBoxItem);

                var control = listBoxItem as Control;
                if (control != null) itemsHeight += control.Height;
                itemAvgHeight = ((float)itemsHeight) / _listBoxItems.Count;
            }

            while (_dataPanel.Height - itemsHeight < 0)
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

        readonly List<IListBoxItem<T>> _listBoxItems = new List<IListBoxItem<T>>();
        private void AddListBoxItem(IListBoxItem<T> listBoxItem)
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
                _dataPanel.Controls.Add(listBoxItem as Control);
                _listBoxItems.Add(listBoxItem);
            }
        }

        protected virtual IListBoxItem<T> GetNewListItem()
        {
            return new VirtualListBoxItem<T>();
        }

        private void RemoveListBoxItem()
        {
            var listBoxItem = _listBoxItems[_listBoxItems.Count - 1];
            if (_dataPanel.Controls.Contains(listBoxItem as Control))
                _dataPanel.Controls.Remove(listBoxItem as Control);

            listBoxItem.DataNeeded -= ListBoxItemDataNeeded;
            _listBoxItems.Remove(listBoxItem);
        }

        void ListBoxItemDataNeeded(object sender)
        {
            if (ItemDataNeeded != null)
                ItemDataNeeded.Invoke(this, sender as IListBoxItem<T>);
        }

        private void ReindexItems()
        {
            for (int i = 0; i < _listBoxItems.Count; i++)
            {
                _listBoxItems[i].Index = _vScrollBar.Value + (-_vScrollBar.Minimum) + i;
            }
        }

        #endregion

        #region Event Handlers

        private void ListBoxResize(object sender, EventArgs e)
        {
            FillItemPanel();

            if (_itemCount > _listBoxItems.Count)
                _vScrollBar.Show();
            else
                _vScrollBar.Hide();

            _vScrollBar.Maximum = _itemCount - _listBoxItems.Count;
        }

        private void VScrollBarValueChanged(object sender, EventArgs e)
        {
            ReindexItems();
        }

        #endregion
    }
}
