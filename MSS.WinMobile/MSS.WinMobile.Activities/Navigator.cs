using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MSS.WinMobile.Activities
{
    public class Navigator : INavigator
    {
        IContainer _container;

        public Navigator(IContainer container) 
        {
            _container = container;
        }

        #region INavigator Members

        public void NavigateTo(string formName)
        {
            switch (formName) {
                case "Home": {
                    Home home = new Home();
                    _container.Register(home);
                    break;
                }
                case "Route": {
                    Route route = new Route();
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
