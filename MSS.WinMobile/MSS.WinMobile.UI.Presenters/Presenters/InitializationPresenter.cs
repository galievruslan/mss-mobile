using System.ComponentModel;
using MSS.WinMobile.Common.Observable;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class InitializationPresenter : IPresenter, IObserver
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

        public void InitializeView()
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _view.CloseView();
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Notify(new ProgressNotification(0));
            RetrieversCache.InitializeCurrentRoutePointRetriever();
            Notify(new ProgressNotification(100));
        }
    }
}
