using System;
using System.Globalization;
using MSS.WinMobile.Infrastructure.Remote.Data;
using MSS.WinMobile.UI.ViewModel;

namespace MSS.WinMobile.UI.Presenters
{
    public class LogonPresenter : Presenter
    {
        private readonly Uri _serverUri;

        private readonly ILayout _layout;
        private readonly ILogonView _view;

        public LogonPresenter(ILayout layout, ILogonView view)
            :base(layout)
        {
            _layout = layout;
            _view = view;

            _serverUri = new Uri(string.Format("http://{0}:{1}/",
                                               ConfigurationManager.AppSettings["ServerAddress"],
                                               ConfigurationManager.AppSettings["ServerPort"]));
        }

        public void Logon()
        {
            var logonModel = new LogonModel { Username = _view.Account, Password = _view.Password };
            if (logonModel.Validate())
            {
                using (Server server = Server.Logon(_serverUri, logonModel.Username, logonModel.Password))
                {
                    var profile = server.UserService.GetProfile();
                    Context.ManagerId = profile.ManagerId;

                    ConfigurationManager.AppSettings.Add("ServerUsername", logonModel.Username);
                    ConfigurationManager.AppSettings.Add("ServerPassword", logonModel.Password);
                    ConfigurationManager.AppSettings.Add("ContextManagerId",
                                                         Context.ManagerId.ToString(CultureInfo.InvariantCulture));
                    ConfigurationManager.Save();
                    _layout.Navigate<IMenuView>();
                }
            }
            else
            {
                _layout.ShowErrorDialog(logonModel.Errors.ToString());
            }
        }

        public void Cancel()
        {
            Layout.Exit();
        }
    }
}
