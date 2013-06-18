using System;
using System.Threading;
using System.Windows.Forms;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Common.Observable;
using MSS.WinMobile.Localization;
using MSS.WinMobile.Updater.Commands;
using Environment = MSS.WinMobile.Application.Environment.Environment;

namespace MSS.WinMobile.Updater {
    public partial class Updater : Form, IObserver {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof (Updater));

        public Updater() {
            InitializeComponent();
        }

        private readonly TargetConfig _targetConfig;
        private readonly IConfigurationManager _configurationManager;
        private readonly ILocalizationManager _localizationManager;

        public Updater(TargetConfig targetConfig,
                       IConfigurationManager configurationManager,
                       ILocalizationManager localizationManager)
            : this() {
            _targetConfig = targetConfig;
            _configurationManager = configurationManager;
            _localizationManager = localizationManager;
        }

        private Thread _worker;

        private void UpdaterLoad(object sender, EventArgs e) {
            var parametrizedThreadStartDelegate =
                new ParametrizedThreadStartDelegate(_targetConfig, _configurationManager);
            parametrizedThreadStartDelegate.Subscribe(this);
            parametrizedThreadStartDelegate.UpdateComplete += UpdateCompleteHandler;
            parametrizedThreadStartDelegate.UpdateNotNeeded += UpdateNotNeededHandler;
            parametrizedThreadStartDelegate.UpdateFailed += UpdateFailedHandler;

            _worker = new Thread(parametrizedThreadStartDelegate.Worker);
            _worker.Start();
        }

        private delegate void UpdateStatusDelegate(string status);
        private void UpdateActionStatus(string status) {
            if (_statusLabel.InvokeRequired) {
                _statusLabel.Invoke(new UpdateStatusDelegate(UpdateActionStatus), status);
            }
            else {
                if (_statusLabel.Text != string.Empty)
                    _statusLabel.Text += Environment.ReturnWithNewLine;

                _statusLabel.Text += _localizationManager.Localization.GetLocalizedValue(status);
            }
        }

        private void UpdateActionResultStatus(string status) {
            if (_statusLabel.InvokeRequired) {
                _statusLabel.Invoke(new UpdateStatusDelegate(UpdateActionResultStatus), status);
            }
            else {
                _statusLabel.Text += _localizationManager.Localization.GetLocalizedValue(status);
            }
        }

        private delegate void UpdateFinishedHandlerDelegate();
        private void UpdateCompleteHandler() {
            if (InvokeRequired) {
                Invoke(new UpdateFinishedHandlerDelegate(UpdateCompleteHandler));
            }
            else {
                MessageBox.Show(
                    _localizationManager.Localization.GetLocalizedValue(
                        "New version of the programm installed."));
                Close();
                Dispose();
            }
        }

        private void UpdateNotNeededHandler() {
            if (InvokeRequired) {
                Invoke(new UpdateFinishedHandlerDelegate(UpdateNotNeededHandler));
            }
            else {
                MessageBox.Show(
                    _localizationManager.Localization.GetLocalizedValue(
                        "Lastes updates already installed."));
                Close();
                Dispose();
            }
        }

        private void UpdateFailedHandler() {
            if (InvokeRequired) {
                Invoke(new UpdateFinishedHandlerDelegate(UpdateFailedHandler));
            }
            else {
                MessageBox.Show(
                    _localizationManager.Localization.GetLocalizedValue(
                        "Update failed, please try again later."));
                Close();
                Dispose();
            }
        }

        public void Notify(INotification notification) {
            if (notification is TextNotification) {
                var textNotification = notification as TextNotification;
                UpdateActionStatus(textNotification.Text);
            }
            else if (notification is CommandResultNotification) {
                var commandResultNotification = notification as CommandResultNotification;
                UpdateActionResultStatus(commandResultNotification.Result);
            }
        }

        private void UpdaterClosing(object sender, System.ComponentModel.CancelEventArgs e) {
            try {
                if (_worker != null)
                    _worker.Abort();
            }
            catch (Exception exception) {
                Log.Error(exception);
            }
        }
    }
}