using System.Drawing;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls {
    public partial class VericalLine : UserControl {
        public VericalLine() {
            InitializeComponent();
            LineColor = Color.DarkGray;
        }

        public Color LineColor { get; set; }

        private void VericalLine_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawLine(new Pen(LineColor, 1), 3, 3, 3, Height - 6);
        }
    }
}
