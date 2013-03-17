using System;

namespace MSS.WinMobile.UI.Presenters
{
    public interface IOrderView : IView
    {
        void SetNumber(int number);
        void SetDate(DateTime date);
        void SetCustomer(string customer);
        void SetShipmentAddress(string address);
        void SetPrice(string price);
        void SetWarehouse(string warehouse);

        void SetNote(string note);
    }
}
