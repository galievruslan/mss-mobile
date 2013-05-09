using System.Drawing;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Concret
{
    public class RoutePointListBox : VirtualListBox
    {
        public RoutePointListBox() {
            InitializeComponent();
            Paint += RoutePointListBox_Paint;
        }

        protected override VirtualListBoxItem NewItem()
        {
            return new RoutePointListBoxItem();
        }

        private void RoutePointListBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
            if (ItemCount == 0) {
                e.Graphics.DrawString("Where are no route points.", Font, new SolidBrush(ForeColor), e.ClipRectangle);
            }
        }
    }
}
