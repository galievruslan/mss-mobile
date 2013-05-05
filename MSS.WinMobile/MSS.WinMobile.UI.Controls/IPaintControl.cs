using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls {
    public interface IPaintControl {
        // have the background painted
        void InvokePaintBackground(PaintEventArgs e);
    }
}
