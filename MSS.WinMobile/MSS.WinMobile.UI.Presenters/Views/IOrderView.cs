using System;

namespace MSS.WinMobile.UI.Presenters.Views
{
    public interface IOrderView : IListView
    {
        void SetNumber(string number);
        void SetDate(DateTime date);
        void SetCustomer(string name);
        void SetShippingAddress(string address);
        void SetPriceList(string name);
        void SetWarehouse(string address);
    }
}
