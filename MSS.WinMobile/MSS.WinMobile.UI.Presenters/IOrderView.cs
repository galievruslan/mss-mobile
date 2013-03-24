using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.UI.Presenters
{
    public interface IOrderView : IView
    {
        void SetOrder(Order order);
    }
}
