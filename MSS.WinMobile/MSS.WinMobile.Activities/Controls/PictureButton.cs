﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MSS.WinMobile.Activities.Controls
{
    public partial class PictureButton : UserControl
    {
        public PictureButton()
        {
            InitializeComponent();
        }

        Image backgroundImage, pressedImage;
        bool pressed = false;

        // Property for the background image to be drawn behind the button text.
        public Image BackgroundImage
        {
            get
            {
                return this.backgroundImage;
            }
            set
            {
                this.backgroundImage = value;
            }
        }

        // Property for the background image to be drawn behind the button text when
        // the button is pressed.
        public Image PressedImage
        {
            get
            {
                return this.pressedImage;
            }
            set
            {
                this.pressedImage = value;
            }
        }

        // When the mouse button is pressed, set the "pressed" flag to true 
        // and invalidate the form to cause a repaint.  The .NET Compact Framework 
        // sets the mouse capture automatically.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.pressed = true;
            this.Invalidate();
            base.OnMouseDown(e);
        }

        // When the mouse is released, reset the "pressed" flag 
        // and invalidate to redraw the button in the unpressed state.
        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.pressed = false;
            this.Invalidate();
            base.OnMouseUp(e);
        }

        // Override the OnPaint method to draw the background image and the text.
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.pressed && this.pressedImage != null)
                e.Graphics.DrawImage(this.pressedImage, 0, 0);
            else if (this.backgroundImage != null)
                e.Graphics.DrawImage(this.backgroundImage, this.ClientRectangle, new Rectangle(0, 0, this.backgroundImage.Width, this.backgroundImage.Height), GraphicsUnit.Pixel);

            // Draw the text if there is any.
            if (this.Text.Length > 0)
            {
                SizeF size = e.Graphics.MeasureString(this.Text, this.Font);

                // Center the text inside the client area of the PictureButton.
                e.Graphics.DrawString(this.Text,
                    this.Font,
                    new SolidBrush(this.ForeColor),
                    (this.ClientSize.Width - size.Width) / 2,
                    (this.ClientSize.Height - size.Height) / 2);
            }

            base.OnPaint(e);
        }
    }
}
