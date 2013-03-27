using System.Drawing;

namespace MSS.WinMobile.UI.Controls.ListBox.ListBoxItems
{
    public class OrderItemListBoxItem : VirtualListBoxItem
    {
        private const string NameKey = "Name";

        protected override void DrawItem(Graphics graphics, Rectangle rectangle)
        {
            string name = NameKey;
            if (Data.ContainsKey(NameKey))
                name = Data[NameKey];

            graphics.DrawString(name, Constants.Font,
                                IsSelected
                                    ? new SolidBrush(Constants.ColorFontSelected)
                                    : new SolidBrush(Constants.ColorFontUnSelected),
                                new Rectangle(rectangle.X + Constants.MARGIN, rectangle.Y + Constants.MARGIN,
                                              rectangle.Width - 2 * Constants.MARGIN,
                                              rectangle.Height - 2 * Constants.MARGIN));
        }
    }
}
