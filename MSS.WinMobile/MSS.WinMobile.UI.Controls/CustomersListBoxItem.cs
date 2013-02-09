using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Controls.ListBox;

namespace MSS.WinMobile.UI.Controls
{
    public partial class CustomersListBoxItem : VirtualListBoxItem<Customer>
    {
        public CustomersListBoxItem()
        {
            InitializeComponent();
        }

        protected override void DispalyData()
        {
            base.DispalyData();

            if (Data != null)
                _textLabel.Text = Data.Name;
        }
    }
}
