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

        public static void NavigateTo<T>(IDictionary<string, object> args) where T : class, IView
        {
            if (_navigator != null) {
                _navigator.NavigateTo<T>(args);
                return;
            }

            throw new NavigatorNotRegistredException();
        }

        public static void NavigateTo<T>() where T : class, IView
        {
            NavigateTo<T>(new Dictionary<string, object>());
        }
    }

    public class NavigatorNotRegistredException : Exception
    {
    }
}
