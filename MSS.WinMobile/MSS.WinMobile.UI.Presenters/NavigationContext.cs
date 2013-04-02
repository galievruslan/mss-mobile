using System;
using System.Collections.Generic;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Presenters
{
    public static class NavigationContext
    {
        private static INavigator _navigator;
        public static void RegisterNavigator(INavigator navigator)
        {
            _navigator = navigator;
        }

        public static T NavigateTo<T>(IDictionary<string, object> args) where T : class, IView
        {
            if (_navigator != null)
                return _navigator.NavigateTo<T>(args);

            throw new NavigatorNotRegistredException();
        }

        public static T NavigateTo<T>() where T : class, IView
        {
            return NavigateTo<T>(new Dictionary<string, object>());
        }
    }

    public class NavigatorNotRegistredException : Exception
    {
    }
}
