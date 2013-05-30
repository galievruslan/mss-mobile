using System;
using System.Windows.Forms;
using MSS.WinMobile.Resources;

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

        private ILocalizator _localizator;
        public ILocalizator Localizator {
            private get { return _localizator; }
            set { 
                _localizator = value;
                if (_localizator != null) {
                    _searchTextBox.TextPrompt =
                        _localizator.Localization.GetLocalizedValue(_searchTextBox.TextPrompt);
                }
            }
        }

        private void SearchButtonClick(object sender, EventArgs e)
        {
            if (Search != null)
                Search.Invoke(this, _searchTextBox.Text);
        }

        private void _clearButton_Click(object sender, EventArgs e) {
            if (Clear != null)
                Clear.Invoke(this);

            _searchTextBox.Text = string.Empty;
        }
    }
}
