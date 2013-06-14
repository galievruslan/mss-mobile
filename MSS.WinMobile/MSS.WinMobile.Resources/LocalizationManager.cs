using System;
using System.Collections.Generic;
using System.IO;
using MSS.WinMobile.Resources;
using log4net;

namespace MSS.WinMobile.Localization {
    public class LocalizationManager : ILocalizationManager {
        private static readonly ILog Log = LogManager.GetLogger(typeof (LocalizationManager));

        private readonly string _localizationPaths;
        public LocalizationManager(string localizationsPath) {
            _localizationPaths = localizationsPath;
        }

        public void SetupLocalization(ILocalization localization) {
            Localization = localization;
            Localization.Load();
        }

        public ILocalization Localization { get; private set; }

        public List<ILocalization> GetAvailableLocalizations(string applicationPath) {
            var localizations = new List<ILocalization>();

            string[] localizationFiles = Directory.GetFiles(_localizationPaths, "*.xml");
            foreach (var localizationFile in localizationFiles) {
                try {
                    localizations.Add(new Resources.Localization(localizationFile));
                }
                catch (Exception exception) {
                    Log.Error(exception);
                }
            }

            return localizations;
        }
    }
}
