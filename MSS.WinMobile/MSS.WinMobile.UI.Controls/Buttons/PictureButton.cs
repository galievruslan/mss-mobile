using System.Drawing;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Controls.Buttons
{
    public partial class PictureButton : UserControl
    {
        public PictureButton()
        {
            InitializeComponent();
        }

        Image _backgroundImage, _pressedImage;
        bool _pressed;

        // Property for the background image to be drawn behind the button text.
        public Image BackgroundImage
        {
            get
            {
                return _backgroundImage;
            }
            set
            {
                _backgroundImage = value;
            }
        }

        // Property for the background image to be drawn behind the button text when
        // the button is pressed.
        public Image PressedImage
        {
            get
            {
                return _pressedImage;
            }
            set
            {
                _pressedImage = value;
            }
        }

        // When the mouse button is pressed, set the "pressed" flag to true 
        // and invalidate the form to cause a repaint.  The .NET Compact Framework 
        // sets the mouse capture automatically.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _pressed = true;
            Invalidate();
            base.OnMouseDown(e);
        }

        // When the mouse is released, reset the "pressed" flag 
        // and invalidate to redraw the button in the unpressed state.
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _pressed = false;
            Invalidate();
            base.OnMouseUp(e);
        }

        // Override the OnPaint method to draw the background image and the text.
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_pressed && _pressedImage != null)
                e.Graphics.DrawImage(_pressedImage, ClientRectangle, new Rectangle(0, 0, _backgroundImage.Width, _backgroundImage.Height), GraphicsUnit.Pixel);
            else if (_backgroundImage != null)
                e.Graphics.DrawImage(_backgroundImage, ClientRectangle, new Rectangle(0, 0, _backgroundImage.Width, _backgroundImage.Height), GraphicsUnit.Pixel);

            // Draw the text if there is any.
            if (Text.Length > 0)
            {
                SizeF size = e.Graphics.MeasureString(Text, Font);

                // Center the text inside the client area of the PictureButton.
                e.Graphics.DrawString(Text,
                    Font,
                    new SolidBrush(ForeColor),
                    (ClientSize.Width - size.Width) / 2,
                    (ClientSize.Height - size.Height) / 2);
            }

            base.OnPaint(e);
        }
    }
}
