using System;

namespace MSS.WinMobile.UI.Presenters.ViewModels
{
    public class SynchronizationViewModel : ViewModel
    {
        public bool SynchronizeFully { get; set; }
        public DateTime LastSynchronizationDate { get; set; }
    }
}
