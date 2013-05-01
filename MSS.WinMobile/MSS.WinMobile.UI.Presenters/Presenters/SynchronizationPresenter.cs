using System;
using System.Threading;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.Common.Observable;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class SynchronizationPresenter : IPresenter, IObserver
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SynchronizationPresenter));

        private readonly Application.Configuration.ConfigurationManager _configurationManager;
        private readonly ISynchronizationView _view;

        public SynchronizationPresenter(ISynchronizationView view)
        {
            _configurationManager = new Application.Configuration.ConfigurationManager(Environments.AppPath);
            _view = view;
        }

        private Thread _thread;

        public void Synchronize()
        {
            _thread = new Thread(RunSynchronizationInBackground);
            _thread.Start();
        }

        private void RunSynchronizationInBackground() {
            //var serverUri = new Uri(ConfigurationManager.AppSettings["ServerAddress"]);

            //var userName = ConfigurationManager.AppSettings["ServerUsername"];
            //var password = ConfigurationManager.AppSettings["ServerPassword"];

            //using (var server = Server.Logon(serverUri, userName, password)) {
            //    var command = new SynchronizeAll(server).IgnoreOnError(false);
            //    command.Subscribe(this);
            //    command.Do();
            //}

            _view.CloseView();
        }

        public void Cancel()
        {
            try
            {
                if (_thread != null)
                    _thread.Abort();
            }
            catch (ThreadAbortException threadAbortException)
            {
                Log.Error("Synchronization cancelation error", threadAbortException);
            }
        }

        #region IObserver

        public void Notify(INotification notification)
        {
            if (notification is TextNotification)
            {
                var textNotification = notification as TextNotification;
                _view.UpdateStatus(textNotification.Text);
            }
            else if (notification is ProgressNotification)
            {
                var progressNotification = notification as ProgressNotification;
                _view.UpdateProgress(progressNotification.Progress);
            }
        }

        #endregion

        public SynchronizationViewModel InitializeView() {
            var lastSynchronizationDate =
                _configurationManager.GetConfig("Common")
                                     .GetSection("Synchronization")
                                     .GetSetting("LastSyncDate")
                                     .As<DateTime>();
            return new SynchronizationViewModel
                {
                    SynchronizeFully = false,
                    LastSynchronizationDate = lastSynchronizationDate
                };
        }
    }
}
