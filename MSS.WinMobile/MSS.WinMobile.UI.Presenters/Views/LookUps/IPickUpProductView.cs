using System.Collections.Generic;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Presenters.Views.LookUps
{
    public interface IPickUpProductView : IListView
    {
        IList<PickUpProductViewModel> PickedUpProducts { get; }
    }
}
