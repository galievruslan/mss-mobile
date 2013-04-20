using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using Json;
using MSS.WinMobile.Infrastructure.Server;
using MSS.WinMobile.Infrastructure.Server.Dtos;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class LogonPresenter : IPresenter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LogonPresenter));

        private readonly Application.Configuration.Manager _configurationManager;
        private readonly ILogonView _view;

        public LogonPresenter(ILogonView view)
        {
            _configurationManager = new Application.Configuration.Manager(Context.GetAppPath());
            _view = view;
        }

        public void Logon()
        {

            string serverAddress = _configurationManager.GetConfig("Common").GetSection("Server").GetSetting("Address").Value;

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
                using (Server server = Server.Logon(new Uri(serverAddress), _view.Account, _view.Password))
                {
                    var profile = server.Get(@"/profile/show.json", new Dictionary<string, object>());
                    Context.ManagerId = JsonDeserializer.Deserialize<ProfileDto>(profile).ManagerId;

                    _configurationManager.GetConfig("Common").GetSection("Server").GetSetting("Username").Value = _view.Account;
                    _configurationManager.GetConfig("Common").GetSection("Server").GetSetting("Password").Value = _view.Password;
                    _configurationManager.GetConfig("Common").GetSection("ExecutionContext").GetSetting("ManagerId").Value =
                                                         Context.ManagerId.ToString(CultureInfo.InvariantCulture);
                    _configurationManager.GetConfig("Common").Save();
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
