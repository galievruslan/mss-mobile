using System;
using System.Collections.Generic;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Common.Observable;
using MSS.WinMobile.Updater.Commands;

namespace MSS.WinMobile.Updater {
    internal sealed class ParametrizedThreadStartDelegate : IObservable, IObserver {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(ParametrizedThreadStartDelegate));

        private readonly TargetConfig _targetConfig;
        private readonly IConfigurationManager _configurationManager;
        public ParametrizedThreadStartDelegate(TargetConfig targetConfig, IConfigurationManager configurationManager) {
            _targetConfig = targetConfig;
            _configurationManager = configurationManager;
        }

        public delegate void OnUpdateComplete();
        public event OnUpdateComplete UpdateComplete;

        private void InvokeUpdateComplete() {
            OnUpdateComplete handler = UpdateComplete;
            if (handler != null) handler();
        }

        public void Worker() {
            try {
                var setupUpdateServer = new SetupUpdateServer(_configurationManager);
                setupUpdateServer.Subscribe(this);
                using (var webServer = setupUpdateServer.Execute()) {
                    setupUpdateServer.Dispose();

                    var connectToUpdateServer = new ConnectToUpdateServer(webServer);
                    connectToUpdateServer.Subscribe(this);
                    using (var connection = connectToUpdateServer.Execute()) {
                        connectToUpdateServer.Dispose();

                        var getUpdateInfo = new GetUpdateInfo(connection, _configurationManager);
                        getUpdateInfo.Subscribe(this);
                        var updateInfo = getUpdateInfo.Execute();
                        getUpdateInfo.Dispose();

                        var checkIfUpdateAvailable = new CheckIfUpdateAvailable(_targetConfig,
                                                                                updateInfo);
                        checkIfUpdateAvailable.Subscribe(this);
                        if (checkIfUpdateAvailable.Execute()) {
                            var createTemporaryFolder = new CreateTemporaryFolder();
                            createTemporaryFolder.Subscribe(this);
                            string temporaryFolder = createTemporaryFolder.Execute();
                            createTemporaryFolder.Dispose();

                            var downloadDistributive = new DownloadDistributive(webServer,
                                                                                updateInfo,
                                                                                temporaryFolder);
                            downloadDistributive.Subscribe(this);
                            string archivedDistributive = downloadDistributive.Execute();
                            downloadDistributive.Dispose();

                            var extractDistributive = new ExtractDistributive(archivedDistributive,
                                                                              temporaryFolder);
                            extractDistributive.Subscribe(this);
                            string distributive = extractDistributive.Execute();
                            extractDistributive.Dispose();

                            var killTargetProcess = new KillTargetProcess(_targetConfig);
                            killTargetProcess.Subscribe(this);
                            killTargetProcess.Execute();
                            killTargetProcess.Dispose();

                            var installNewVersion = new InstallNewVersion(distributive);
                            installNewVersion.Subscribe(this);
                            installNewVersion.Execute();
                            installNewVersion.Dispose();

                            var runApplication = new RunApplication(_targetConfig);
                            runApplication.Subscribe(this);
                            runApplication.Execute();
                            runApplication.Dispose();

                            var deleteTemporaryFolder = new DeleteTemporaryFolder(temporaryFolder);
                            deleteTemporaryFolder.Execute();
                        }
                        checkIfUpdateAvailable.Dispose();
                    }
                }
            }
            catch (Exception exception) {
                Log.Error(exception);
            }

            InvokeUpdateComplete();
        }

        #region IDisposable
        public void Dispose() {
            while (_observers.Count > 0) {
                Unsubscribe(_observers[0]);
            }
        }
        #endregion

        #region IObservable
        readonly List<IObserver> _observers = new List<IObserver>();

        public void Subscribe(IObserver observer) {
            if (!_observers.Contains(observer)) {
                lock (_observers) {
                    _observers.Add(observer);
                }
            }
        }

        public void Unsubscribe(IObserver observer) {
            if (_observers.Contains(observer)) {
                lock (_observers) {
                    _observers.Remove(observer);
                }
            }
        }

        private void Notificate(INotification notification) {
            foreach (var observer in _observers) {
                try {
                    observer.Notify(notification);
                }
                catch (Exception exception) {
                    Log.Error(string.Format("Notify observer {0} failed!", observer), exception);
                }
            }
        }

        public void Notify(INotification notification) {
            Log.DebugFormat("notification received {0}", notification);
            Notificate(notification);
        }
        #endregion
    }
}
