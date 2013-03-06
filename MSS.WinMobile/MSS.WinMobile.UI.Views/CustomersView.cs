using System.Windows.Forms;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Presenters;

namespace MSS.WinMobile.UI.Views
{
    public partial class CustomersView : UserControl, ICustomersView
    {
        public CustomersView()
        {
            InitializeComponent();
        }

        public CustomersView(ILayout layout)
        {
            InitializeComponent();
        }
    }
}
