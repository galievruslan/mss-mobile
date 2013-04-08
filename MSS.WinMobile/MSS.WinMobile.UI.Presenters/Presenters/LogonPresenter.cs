using System;
using System.Globalization;
using System.Net;
using MSS.WinMobile.Infrastructure.Server;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class LogonPresenter : IPresenter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LogonPresenter));

        private readonly Uri _serverUri;
        private readonly ILogonView _view;

        public LogonPresenter(ILogonView view)
        {
            _view = view;
            _serverUri = new Uri(ConfigurationManager.AppSettings["ServerAddress"]);
        }

        public void Logon()
        {
            if (string.IsNullOrEmpty(_view.Account))
            {
                _view.DisplayErrors("Account can't be empty!");
                return;
            }

            if (string.IsNullOrEmpty(_view.Password))
            {
                _view.DisplayErrors("Password can't be empty!");
                return;
            }

            try
            {
                using (Server server = Server.Logon(_serverUri, _view.Account, _view.Password))
                {
                    var profile = server.UserService.GetProfile();
                    Context.ManagerId = profile.ManagerId;

                    ConfigurationManager.AppSettings.Set("ServerUsername", _view.Account);
                    ConfigurationManager.AppSettings.Set("ServerPassword", _view.Password);
                    ConfigurationManager.AppSettings.Set("ContextManagerId",
                                                         Context.ManagerId.ToString(CultureInfo.InvariantCulture));
                    ConfigurationManager.Save();
                    NavigationContext.NavigateTo<IInitializationView>().ShowView();
                    _view.CloseView();
                }
            }
            catch (WebException webException)
            {
                Log.Error(webException);
                _view.DisplayErrors("Can't connect to the server!");
            }
        }

        public void Cancel()
        {
        }

        public void InitializeView()
        {
            
        }
    }
}
