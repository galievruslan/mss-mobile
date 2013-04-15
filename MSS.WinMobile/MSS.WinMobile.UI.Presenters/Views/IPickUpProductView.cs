using System.Collections.Generic;

namespace MSS.WinMobile.UI.Presenters.Views
{
    public interface IPickUpProductView : IListView
    {
        IDictionary<int, int> GetValues();
    }
}
