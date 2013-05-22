using System;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls
{
    public partial class SearchPanel : UserControl
    {
        public delegate void OnSearch(object sender, string criteria);
        public delegate void OnClear(object sender);
        public event OnSearch Search;
        public event OnClear Clear;

        public SearchPanel()
        {
            InitializeComponent();
        }

        private void _searchButton_Click(object sender, EventArgs e)
        {
            if (Search != null)
                Search.Invoke(this, _searchTextBox.Text);
        }

        private void _clearButton_Click(object sender, EventArgs e) {
            if (Clear != null)
                Clear.Invoke(this);
        }
    }
}
