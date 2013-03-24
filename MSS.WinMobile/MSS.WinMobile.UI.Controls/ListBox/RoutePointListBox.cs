using System;

using System.Collections.Generic;
using System.Text;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.ListBox
{
    public class RoutePointListBox : VirtualListBox<RoutePoint>
    {
        protected override VirtualListBoxItem<RoutePoint> NewItem()
        {
            return new RoutePointListBoxItem();
        }
    }
}
