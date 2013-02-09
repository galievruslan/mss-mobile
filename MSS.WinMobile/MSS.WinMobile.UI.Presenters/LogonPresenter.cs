using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.UI.Presenters
{
    public class LogonPresenter : Presenter
    {
        private readonly ILogonView _view;
        private readonly ISession _remoteSession;
        private readonly ISession _localSession;

        public LogonPresenter(ILayout layout, ILogonView view)
            :base(layout)
        {
            _view = view;
            //_remoteSession = new Infrastructure.Remote.Data.Session("192.168.0.102",
            //                             3000, string.Empty, string.Empty);
            //_localSession = new Infrastructure.Local.Data.Session(Path.GetDirectoryName (Assembly.GetExecutingAssembly ().GetName ().CodeBase) + @"/Storage.sdf");
        }

        public void Logon()
        {
            //var logonModel = new LogonModel {Account = _view.Account, Password = _view.Password};
            //if (logonModel.Validate())
            //{
            //    using (ITransaction remoteTransaction = _remoteSession.BeginTransaction())
            //    {
            //        IGenericRepository<Manager> managerRemoteRepo = remoteTransaction.Resolve<Manager>();
            //        var specification = new ManagerWithNameSpecification(_view.Account);
            //        Manager[] managers = managerRemoteRepo.Find(specification);

            //        if (managers.Length > 0)
            //        {
            //            Manager manager = managers[0];
            //            using (ITransaction localTransaction = _localSession.BeginTransaction())
            //            {
            //                IGenericRepository<Manager> managerLocalRepo = localTransaction.Resolve<Manager>();
            //                managerLocalRepo.Add(manager);
            //                localTransaction.Commit();
                            Layout.Navigate<IMenuView>();
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    _view.ShowErrorDialog(logonModel.Errors.ToString());
            //}
        }

        public void Cancel()
        {
            Layout.Exit();
        }
    }
}
