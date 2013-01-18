using System.IO;
using System.Reflection;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Specifications;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.UI.ViewModel;

namespace MSS.WinMobile.UI.Presenters
{
    public class LogonPresenter : Presenter
    {
        private readonly ILogonView _logonView;
        private readonly ISession _remoteSession;
        private readonly ISession _localSession;

        public LogonPresenter(ILogonView logonView)
        {
            _logonView = logonView;
            _remoteSession = new Infrastructure.Remote.Data.Session("192.168.0.102",
                                         3000);
            _localSession = new Infrastructure.Local.Data.Session(Path.GetDirectoryName (Assembly.GetExecutingAssembly ().GetName ().CodeBase) + @"/Storage.sdf");
        }

        public void Logon()
        {
            var logonModel = new LogonModel {Account = _logonView.Account, Password = _logonView.Password};
            if (logonModel.Validate())
            {
                using (ITransaction remoteTransaction = _remoteSession.BeginTransaction())
                {
                    IGenericRepository<Manager> managerRemoteRepo = remoteTransaction.Resolve<Manager>();
                    var specification = new ManagerWithNameSpecification(_logonView.Account);
                    Manager[] managers = managerRemoteRepo.Find(specification);

                    if (managers.Length > 0)
                    {
                        Manager manager = managers[0];
                        using (ITransaction localTransaction = _localSession.BeginTransaction())
                        {
                            IGenericRepository<Manager> managerLocalRepo = localTransaction.Resolve<Manager>();
                            managerLocalRepo.Add(manager);
                            localTransaction.Commit();
                            _logonView.NavigateTo<IMenuView>();
                        }
                    }
                }
            }
            else
            {
                _logonView.ShowErrorDialog(logonModel.Errors.ToString());
            }
        }

        public void Cancel()
        {
            _logonView.Exit();
        }
    }
}
