using System;
using System.Linq;

namespace MSS.WinMobile.UI.Presenters.ViewModels
{
    public class OrderItemViewModel : ViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
