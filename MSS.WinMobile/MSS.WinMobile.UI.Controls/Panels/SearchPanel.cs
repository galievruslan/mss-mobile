using System;
using System.Windows.Forms;
using MSS.WinMobile.Localization;

namespace MSS.WinMobile.UI.Controls.Panels
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

        private ILocalizationManager _localizationManager;
        public ILocalizationManager LocalizationManager {
            private get { return _localizationManager; }
            set { 
                _localizationManager = value;
                if (_localizationManager != null) {
                    _searchTextBox.TextPrompt =
                        _localizationManager.Localization.GetLocalizedValue(_searchTextBox.TextPrompt);
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
