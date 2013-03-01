using System.Threading;
using MSS.WinMobile.Services;
using log4net;

namespace MSS.WinMobile.UI.Presenters
{
    public class SynchronizationPresenter : Presenter, IObserver
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Synchronizer));

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

        private void RunSynchronizationInBackground()
        {
            using (var synchronizer = new Synchronizer())
            {
                synchronizer.Subscribe(this);
                synchronizer.Start();
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
