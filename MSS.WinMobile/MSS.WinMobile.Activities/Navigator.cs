using System;
using System.Collections.Generic;

namespace MSS.WinMobile.UI.Activities
{
    public class Navigator : INavigator
    {
        readonly IContainer _container;

        public Navigator(IContainer container) 
        {
            _container = container;
        }

        #region INavigator Members

        public void NavigateTo(string formName)
        {
            switch (formName) {
                case "Home": {
                    var home = new Home();
                    _container.Register(home);
                    break;
                }
                case "Route": {
                    var route = new Route();
                    _container.Register(route);
                    break;
                }
            }
        }

        public void NavigateTo(string formName, IDictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
