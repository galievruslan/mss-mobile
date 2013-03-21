using System;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.ListBox
{
    public static class ListBoxItemFactory
    {
        public static VirtualListBoxItem<T> Create<T>() where T : class 
        {
            if (typeof (T) == typeof (Customer))
            {
                return new CustomerListBoxItem() as VirtualListBoxItem<T>;
            } if (typeof(T) == typeof(RoutePoint))
            {
                return new RoutePointListBoxItem() as VirtualListBoxItem<T>;
            }

            throw new InvalidOperationException();
        }
    }
}
