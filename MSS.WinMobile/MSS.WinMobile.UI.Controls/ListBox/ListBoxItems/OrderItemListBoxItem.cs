using System;

using System.Collections.Generic;
using System.Drawing;
using System.Text;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.UI.Controls.ListBox.ListBoxItems
{
    public class OrderItemListBoxItem : VirtualListBoxItem<OrderItem>
    {
        private readonly Color _colorSelected = Color.CornflowerBlue;
        private readonly Color _colorUnSelected = Color.White;
        private readonly Font _font = new Font(FontFamily.GenericSerif, 8.0f, FontStyle.Regular);
        private readonly Color _colorFontSelected = Color.White;
        private readonly Color _colorFontUnSelected = Color.Black;

        private const int Margin = 3;
        private const int DivisorLine = 2;

        protected override void DrawItem(Graphics graphics, Rectangle rectangle)
        {
            graphics.FillRectangle(
                IsSelected ? new SolidBrush(_colorSelected) : new SolidBrush(_colorUnSelected),
                rectangle);

            graphics.DrawString(Data.ProductId.ToString(), _font,
                                IsSelected ? new SolidBrush(_colorFontSelected) : new SolidBrush(_colorFontUnSelected),
                                new Rectangle(rectangle.X + Margin, rectangle.Y + Margin, rectangle.Width - 2 * Margin,
                                              rectangle.Height - 2 * Margin));

            graphics.DrawLine(new Pen(Color.DarkGray), rectangle.X + Margin, rectangle.Height - 2,
                              rectangle.Width - DivisorLine * Margin, rectangle.Height - DivisorLine);
        }
    }
}
