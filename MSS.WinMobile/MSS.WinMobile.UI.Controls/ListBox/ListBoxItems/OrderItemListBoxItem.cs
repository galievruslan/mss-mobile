using System.Drawing;

namespace MSS.WinMobile.UI.Controls.ListBox.ListBoxItems
{
    public class OrderItemListBoxItem : VirtualListBoxItem
    {
        private string _name;
        public void SetName(string name)
        {
            _name = name;
            Empty = false;
        }

        protected override void DrawItem(Graphics graphics, Rectangle rectangle)
        {
            graphics.DrawString(_name, Constants.Font,
                                IsSelected
                                    ? new SolidBrush(Constants.ColorFontSelected)
                                    : new SolidBrush(Constants.ColorFontUnSelected),
                                new Rectangle(rectangle.X + Constants.MARGIN, rectangle.Y + Constants.MARGIN,
                                              rectangle.Width - 2 * Constants.MARGIN,
                                              rectangle.Height - 2 * Constants.MARGIN));
        }
    }
}
