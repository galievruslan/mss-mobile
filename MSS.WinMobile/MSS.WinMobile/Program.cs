using System;
using System.Windows.Forms;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.UI.Views;

namespace MSS.WinMobile
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            //var layout = new Layout();
            //ISession localStorageSession =
            //    new Infrastructure.Local.Data.Session(MobileConfiguration.Settings["LocalStorageFileName"]);
            //ISession remoteStorageSession =
            //    new Infrastructure.Remote.Data.Session(MobileConfiguration.Settings["RemoteStorageAddress"],
            //                                           Int32.Parse(MobileConfiguration.Settings["RemoteStoragePort"]));
            //IActivityFactory activityFactory = new ActivityFactory(localStorageSession, remoteStorageSession);
            //INavigator navigator = new Navigator(layout);
            //navigator.NavigateTo(activityFactory.GetActivity("Home"));
            Application.Run(new LogonView());
        }
    }
}