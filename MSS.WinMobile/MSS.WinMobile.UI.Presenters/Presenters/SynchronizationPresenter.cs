using System;
using System.Threading;
using MSS.WinMobile.Commands.FaultHandling;
using MSS.WinMobile.Commands.Synchronization;
using MSS.WinMobile.Common.Observable;
using MSS.WinMobile.Infrastructure.Server;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class SynchronizationPresenter : IPresenter, IObserver
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SynchronizationPresenter));

        private readonly ISynchronizationView _view;
        public SynchronizationPresenter(ISynchronizationView view)
        {
            _view = view;
        }

        private Thread _thread;

        public void Synchronize()
        {
            _thread = new Thread(RunSynchronizationInBackground);
            _thread.Start();
        }

        private void RunSynchronizationInBackground() {
            var serverUri = new Uri(string.Format("http://{0}:{1}/",
                                                  ConfigurationManager.AppSettings["ServerAddress"],
                                                  ConfigurationManager.AppSettings["ServerPort"]));

            var userName = ConfigurationManager.AppSettings["ServerUsername"];
            var password = ConfigurationManager.AppSettings["ServerPassword"];

            using (var server = Server.Logon(serverUri, userName, password)) {
                var command = new SynchronizeAll(server).IgnoreOnError(false);
                command.Subscribe(this);
                command.Do();
            }
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

        public void InitializeView()
        {
            
        }
    }
}
