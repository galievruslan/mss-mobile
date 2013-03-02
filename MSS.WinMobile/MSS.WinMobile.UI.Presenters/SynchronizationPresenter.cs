using System;
using System.Threading;
using MSS.WinMobile.Commands.FaultHandling;
using MSS.WinMobile.Commands.Synchronization;
using MSS.WinMobile.Common.Observable;
using MSS.WinMobile.Infrastructure.Remote.Data;
using log4net;

namespace MSS.WinMobile.UI.Presenters
{
    public class SynchronizationPresenter : Presenter, IObserver
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SynchronizationPresenter));

        private readonly ISynchronizationView _view;
        public SynchronizationPresenter(ILayout layout, ISynchronizationView view)
            :base(layout)
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

            string databaseName = ConfigurationManager.AppSettings["DatabaseName"];
            var session = new Infrastructure.Local.Data.Session(databaseName);

            using (var server = Server.Logon(serverUri, userName, password)) {
                var command = new SynchronizeAll(server, session).IgnoreOnError(false);
                command.Do();

            }

            Layout.Navigate<IMenuView>();
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

            Layout.Navigate<IMenuView>();
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
    }
}
