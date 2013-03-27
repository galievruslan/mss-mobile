using System.Drawing;

namespace MSS.WinMobile.UI.Controls.ListBox.ListBoxItems
{
    public class ProductPriceListBoxItem : VirtualListBoxItem
    {
        private const string NameKey = "Name";
        private const string PriceKey = "Price";
        private const string CountKey = "Count";

        protected override void DrawItem(Graphics graphics, Rectangle rectangle)
        {
            string name = NameKey;
            if (Data.ContainsKey(NameKey))
                name = Data[NameKey];

            string price = PriceKey;
            if (Data.ContainsKey(PriceKey))
                price = Data[PriceKey];

            string count = CountKey;
            if (Data.ContainsKey(CountKey))
                count = Data[CountKey];

            graphics.DrawString(name, Constants.Font,
                                IsSelected
                                    ? new SolidBrush(Constants.ColorFontSelected)
                                    : new SolidBrush(Constants.ColorFontUnSelected),
                                new Rectangle(rectangle.X + Constants.MARGIN, rectangle.Y + Constants.MARGIN,
                                              rectangle.Width - 2 * Constants.MARGIN - 50,
                                              rectangle.Height / 2 - 2 * Constants.MARGIN));

            graphics.DrawString(price, Constants.Font,
                                IsSelected
                                    ? new SolidBrush(Constants.ColorFontSelected)
                                    : new SolidBrush(Constants.ColorFontUnSelected),
                                new Rectangle(rectangle.X + Constants.MARGIN, rectangle.Y + Constants.MARGIN + rectangle.Height / 2,
                                              rectangle.Width - 2 * Constants.MARGIN - 50,
                                              rectangle.Height / 2 - 2 * Constants.MARGIN));

            graphics.DrawString(count, Constants.Font,
                                IsSelected
                                    ? new SolidBrush(Constants.ColorFontSelected)
                                    : new SolidBrush(Constants.ColorFontUnSelected),
                                new Rectangle(rectangle.Width - 2 * Constants.MARGIN - 50, rectangle.Y + Constants.MARGIN,
                                              50,
                                              rectangle.Height - 2 * Constants.MARGIN));
        }
    }
}
