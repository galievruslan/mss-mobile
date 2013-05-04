using System.ComponentModel;
using MSS.WinMobile.Common.Observable;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class InitializationPresenter : IObserver
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(InitializationPresenter));

        private readonly IInitializationView _view;
        public InitializationPresenter(IInitializationView view)
        {
            _view = view;
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

        private BackgroundWorker _backgroundWorker;
        public void InitializeView()
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += BackgroundWorkerDoWork;
            _backgroundWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerCompleted;
            _backgroundWorker.RunWorkerAsync();
        }

        void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _view.CloseView();
            _backgroundWorker.Dispose();
        }

        void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            Notify(new ProgressNotification(0));
            //RetrieversCache.InitializeCurrentRoutePointRetriever();
            Notify(new ProgressNotification(100));
        }
    }
}
