using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters;

namespace MSS.WinMobile.UI.Views
{
    public partial class CustomersView : Form, ICustomersView
    {
        public CustomersView()
        {
            InitializeComponent();
        }

        public void DisplayErrors(string error)
        {
            throw new System.NotImplementedException();
        }
    }
}
