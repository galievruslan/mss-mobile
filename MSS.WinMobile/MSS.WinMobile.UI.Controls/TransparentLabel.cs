using System.Drawing;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls {
    public class TransparentLabel : TransparentControl {
        private ContentAlignment _textAlign = ContentAlignment.TopLeft;

        public ContentAlignment TextAlign {
            get { return _textAlign; }
            set { _textAlign = value; }
        }

        protected override void OnPaint(PaintEventArgs e) {
            Graphics gfx = e.Graphics;
            if (TextAlign == ContentAlignment.TopLeft) {
                gfx.DrawString(Text, Font,
                               new SolidBrush(ForeColor), ClientRectangle);
            }
            else if (TextAlign == ContentAlignment.TopCenter) {
                SizeF size = gfx.MeasureString(Text, Font);
                int left = Width/2 - (int) size.Width/2;
                var rect = new Rectangle(ClientRectangle.Left + left,
                                         ClientRectangle.Top, (int) size.Width,
                                         ClientRectangle.Height);
                gfx.DrawString(Text, Font,
                               new SolidBrush(ForeColor), rect);
            }
            else if (TextAlign == ContentAlignment.TopRight) {
                SizeF size = gfx.MeasureString(Text, Font);
                int left = Width - (int) size.Width + Left;
                var rect = new Rectangle(ClientRectangle.Left + left,
                                         ClientRectangle.Top, (int) size.Width,
                                         ClientRectangle.Height);
                gfx.DrawString(Text, Font,
                               new SolidBrush(ForeColor), rect);
            }
        }
    }
}