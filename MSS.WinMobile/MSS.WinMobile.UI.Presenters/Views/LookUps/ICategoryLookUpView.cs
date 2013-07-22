using System.Collections.Generic;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Presenters.Views.LookUps {
    public interface ICategoryLookUpView {
        IEnumerable<CategoryViewModel> SelectedCategories { get; }
    }
}
