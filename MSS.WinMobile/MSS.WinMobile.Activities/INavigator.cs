using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MSS.WinMobile.Activities
{
    public interface INavigator
    {
        void NavigateTo(string formName);

        void NavigateTo(string formName, IDictionary<string, object> parameters);
    }
}
