using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls
{
    public partial class FilterPanel : UserControl
    {
        public delegate void OnFilter(object sender);
        public event OnFilter Filter;

        public delegate void OnClear(object sender);
        public event OnClear Clear;

        public FilterPanel()
        {
            InitializeComponent();
        }

        public void SetFilterValue(string filter) {
            _filterLabel.Text = filter;
        }

        private void FilterButtonClick(object sender, EventArgs e)
        {
            if (Filter != null)
                Filter.Invoke(this);
        }

        private void ClearButtonClick(object sender, EventArgs e) {
            if (Clear != null)
                Clear.Invoke(this);

            _filterLabel.Text = string.Empty;
        }
    }
}
