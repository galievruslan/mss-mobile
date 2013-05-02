using System.Collections.Generic;
using MSS.WinMobile.UI.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;
using MSS.WinMobile.UI.Views;

namespace MSS.WinMobile.Application
{
    public class Navigator : INavigator {
        private readonly PresentersFactory _presentersFactory;
        public Navigator(PresentersFactory presentersFactory) {
            _presentersFactory = presentersFactory;
        }

        public T NavigateTo<T>(IDictionary<string, object> args) where T : class, IView
        {
            T view = default(T);
            if (typeof (T) == typeof (ILogonView))
            {
                view = (new LogonView()) as T;
            }
            else if (typeof(T) == typeof(IMenuView))
            {
                view = (new MenuView()) as T;
            }
            else if (typeof(T) == typeof(IInitializationView))
            {
                view = (new InitializationView()) as T;
            }
            else if (typeof(T) == typeof(ISynchronizationView))
            {
                view = (new SynchronizationView(_presentersFactory)) as T;
            }
            else if (typeof(T) == typeof(IRouteView))
            {
                view = (new RouteView()) as T;
            }
            else if (typeof(T) == typeof(IPickUpProductView))
            {
                view = (new PickUpProductView(args)) as T;
            }

            return view;
        }
    }
}
