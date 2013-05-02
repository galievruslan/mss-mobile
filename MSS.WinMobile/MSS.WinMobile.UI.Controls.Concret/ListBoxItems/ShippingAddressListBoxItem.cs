//using System.Drawing;

//namespace MSS.WinMobile.UI.Controls.ListBox.ListBoxItems
//{
//    public class ShippingAddressListBoxItem : VirtualListBoxItem
//    {
//        private const string AddressKey = "Address";

//        protected override void DrawItem(Graphics graphics, Rectangle rectangle)
//        {
//            string address = AddressKey;
//            if (Data.ContainsKey(AddressKey))
//                address = Data[AddressKey];

//            graphics.DrawString(address, Constants.Font,
//                                IsSelected
//                                    ? new SolidBrush(Constants.ColorFontSelected)
//                                    : new SolidBrush(Constants.ColorFontUnSelected),
//                                new Rectangle(rectangle.X + Constants.MARGIN, rectangle.Y + Constants.MARGIN,
//                                              rectangle.Width - 2 * Constants.MARGIN,
//                                              rectangle.Height - 2 * Constants.MARGIN));
//        }
//    }
//}
