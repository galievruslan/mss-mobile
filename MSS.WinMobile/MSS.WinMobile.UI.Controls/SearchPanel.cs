using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls
{
    public partial class SearchPanel : UserControl
    {
        public delegate void OnSearchNeeded(object sender, string criteria);
        public event OnSearchNeeded SearchNeeded;

        public SearchPanel()
        {
            InitializeComponent();
        }

        private void _searchButton_Click(object sender, EventArgs e)
        {
            if (SearchNeeded != null)
                SearchNeeded.Invoke(this, _searchTextBox.Text);
        }
    }
}
