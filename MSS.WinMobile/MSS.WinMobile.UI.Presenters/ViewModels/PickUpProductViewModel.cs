﻿namespace MSS.WinMobile.UI.Presenters.ViewModels
{
    public class PickUpProductViewModel : ViewModel
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
