using System;
using System.Globalization;
using MSS.WinMobile.Infrastructure.Server;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class LogonPresenter : IPresenter
    {
        private readonly Uri _serverUri;
        private readonly ILogonView _view;

        public LogonPresenter(ILogonView view)
        {
            _view = view;

            _serverUri = new Uri(string.Format("http://{0}:{1}/",
                                               ConfigurationManager.AppSettings["ServerAddress"],
                                               ConfigurationManager.AppSettings["ServerPort"]));
        }

        public void Logon()
        {
            bool errors = false;
            if (string.IsNullOrEmpty(_view.Account))
            {
                _view.DisplayErrors("Account can't be empty!");
                errors = true;
            }

            if (string.IsNullOrEmpty(_view.Password))
            {
                _view.DisplayErrors("Password can't be empty!");
                errors = true;
            }

            if (errors)
                return;

            using (Server server = Server.Logon(_serverUri, _view.Account, _view.Password))
            {
                var profile = server.UserService.GetProfile();
                Context.ManagerId = profile.ManagerId;

                ConfigurationManager.AppSettings.Add("ServerUsername", _view.Account);
                ConfigurationManager.AppSettings.Add("ServerPassword", _view.Password);
                ConfigurationManager.AppSettings.Add("ContextManagerId",
                                                     Context.ManagerId.ToString(CultureInfo.InvariantCulture));
                ConfigurationManager.Save();
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
