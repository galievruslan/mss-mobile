using System;
using System.Collections.Generic;
using MSS.WinMobile.Config;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Specifications;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Remote.Data;

namespace MSS.WinMobile.UI.Presenters
{
    public class LogonPresenter : Presenter
    {
        private readonly ILogonView _logonView;
        private readonly ISession _remoteSession;

        public LogonPresenter(ILogonView logonView)
        {
            _logonView = logonView;
            _remoteSession = new Session(Mobile.Settings["RemoteStorageAddress"],
                                         Int32.Parse(Mobile.Settings["RemoteStoragePort"]));
        }

        public void Logon()
        {
            using (ITransaction transaction = _remoteSession.BeginTransaction())
            {
                IGenericRepository<Manager> managerRepository = transaction.Resolve<Manager>();
                var managers = new List<Manager>(managerRepository.Find(new ManagerWithNameSpecification(_logonView.Account)));
                if (managers.Count > 0)
                {
                    Manager manager = managers[0];
                    _logonView.ShowInformationDialog(manager != null ? "Manager was found!" : "Manager not found!");
                }
            }
        }

        public void Cancel()
        {
        }
    }
}
