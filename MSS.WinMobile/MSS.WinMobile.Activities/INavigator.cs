using System.Collections.Generic;

namespace MSS.WinMobile.UI.Activities
{
    public interface INavigator
    {
        void NavigateTo(string formName);

        void NavigateTo(string formName, IDictionary<string, object> parameters);
    }
}
