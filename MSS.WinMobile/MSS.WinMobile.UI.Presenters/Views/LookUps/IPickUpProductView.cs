using System.Collections.Generic;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Presenters.Views.LookUps
{
    public interface IPickUpProductView : IListView {
        void SetCategoryFilter(string filter);
        void SetAmount(decimal value);
        IList<PickUpProductViewModel> PickedUpProducts { get; }
    }
}
