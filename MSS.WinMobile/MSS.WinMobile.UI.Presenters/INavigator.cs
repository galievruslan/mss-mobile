using System.Collections.Generic;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Presenters
{
    public interface INavigator
    {
        T NavigateTo<T>(IDictionary<string, object> args) where T : class, IView;
    }
}
