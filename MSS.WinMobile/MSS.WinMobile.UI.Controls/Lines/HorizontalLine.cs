using System.Drawing;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls.Lines {
    public partial class HorizontalLine : UserControl {
        public HorizontalLine() {
            InitializeComponent();
            LineColor = Color.DarkGray;
        }

        public Color LineColor { get; set; }

        private void HorizontalLine_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawLine(new Pen(LineColor, 1), 3, 3, Width - 6, 3);
        }
    }
}
