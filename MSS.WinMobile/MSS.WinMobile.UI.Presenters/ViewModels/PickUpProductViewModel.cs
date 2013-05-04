using System;
using System.Linq;

namespace MSS.WinMobile.UI.Presenters.ViewModels
{
    public class PickUpProductViewModel : ViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
