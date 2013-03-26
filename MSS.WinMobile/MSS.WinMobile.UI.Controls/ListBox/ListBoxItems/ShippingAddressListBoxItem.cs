using System.Drawing;

namespace MSS.WinMobile.UI.Controls.ListBox.ListBoxItems
{
    public class ShippingAddressListBoxItem : VirtualListBoxItem
    {
        private string _address;
        public void SetAddress(string address)
        {
            _address = address;
            Empty = false;
        }

        protected override void DrawItem(Graphics graphics, Rectangle rectangle)
        {
            graphics.DrawString(_address, Constants.Font,
                                IsSelected
                                    ? new SolidBrush(Constants.ColorFontSelected)
                                    : new SolidBrush(Constants.ColorFontUnSelected),
                                new Rectangle(rectangle.X + Constants.MARGIN, rectangle.Y + Constants.MARGIN,
                                              rectangle.Width - 2 * Constants.MARGIN,
                                              rectangle.Height - 2 * Constants.MARGIN));
        }
    }
}
