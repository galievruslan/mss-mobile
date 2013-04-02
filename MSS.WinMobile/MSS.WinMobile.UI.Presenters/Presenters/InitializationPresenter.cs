using System.Threading;
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

        private Thread _thread;

        public void Initialize()
        {
            _thread = new Thread(RunInitializationInBackground);
            _thread.Start();
        }

        private void RunInitializationInBackground()
        {
            Notify(new ProgressNotification(0));
            RetrieversCache.InitializeCurrentRoutePointRetriever();
            Notify(new ProgressNotification(100));
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
                Log.Error("Initialization cancelation error", threadAbortException);
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
            Initialize();
        }
    }
}
