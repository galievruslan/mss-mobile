﻿using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.Concret
{
    public class RoutePointListBox : VirtualListBox
    {
        public RoutePointListBox() {
            InitializeComponent();
        }

        protected override VirtualListBoxItem NewItem()
        {
            return new RoutePointListBoxItem();
        }

        protected override string EmptyListMessage {
            get {
                return "Where are no route points on this date.";
            }
        }
    }
}
