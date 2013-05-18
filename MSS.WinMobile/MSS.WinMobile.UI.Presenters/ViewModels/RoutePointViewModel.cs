﻿namespace MSS.WinMobile.UI.Presenters.ViewModels
{
    public class RoutePointViewModel : ViewModel
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public string ShippinAddressName { get; set; }
        public string ShippinAddressAddress { get; set; }
    }
}
